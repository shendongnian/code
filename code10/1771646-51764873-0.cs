    /* this comes from request
    *  request.Fields = "Sender.CityId,Sender.CityName,Recipient.CityName,parcelUniqueId"
    */
    // in the service method
    var shipmentList = _context.Shipments.
                    .OrderByDescending(s => s.Id)
                    .Skip((request.Page -1) * request.PageSize)
                    .Take(request.PageSize)
                    .Select(new SelectLambdaBuilder<Shipment>().CreateNewStatement(request.Fields))
                    .ToList();
    public class SelectLambdaBuilder<T>
    {
        // as a performence consideration I cached already computed type-properties
        private static Dictionary<Type, PropertyInfo[]> _typePropertyInfoMappings = new Dictionary<Type, PropertyInfo[]>();
        private readonly Type _typeOfBaseClass = typeof(T);
        private Dictionary<string, List<string>> GetFieldMapping(string fields)
        {
            var selectedFieldsMap = new Dictionary<string, List<string>>();
            foreach (var s in fields.Split(','))
            {
                var nestedFields = s.Split('.').Select(f => f.Trim()).ToArray();
                var nestedValue = nestedFields.Length > 1 ? nestedFields[1] : null;
                if (selectedFieldsMap.Keys.Any(key => key == nestedFields[0]))
                {
                    selectedFieldsMap[nestedFields[0]].Add(nestedValue);
                }
                else
                {
                    selectedFieldsMap.Add(nestedFields[0], new List<string> { nestedValue });
                }
            }
            return selectedFieldsMap;
        }
        public Func<T, T> CreateNewStatement(string fields)
        {
            ParameterExpression xParameter = Expression.Parameter(_typeOfBaseClass, "s");
            NewExpression xNew = Expression.New(_typeOfBaseClass);
            var selectFields = GetFieldMapping(fields);
            var shpNestedPropertyBindings = new List<MemberAssignment>();
            foreach (var keyValuePair in selectFields)
            {
                PropertyInfo[] propertyInfos;
                if (!_typePropertyInfoMappings.TryGetValue(_typeOfBaseClass, out propertyInfos))
                {
                    var properties = _typeOfBaseClass.GetProperties();
                    propertyInfos = properties;
                    _typePropertyInfoMappings.Add(_typeOfBaseClass, properties);
                }
                var propertyType = propertyInfos
                    .FirstOrDefault(p => p.Name.ToLowerInvariant().Equals(keyValuePair.Key.ToLowerInvariant()))
                    .PropertyType;
                if (propertyType.IsClass)
                {
                    PropertyInfo objClassPropInfo = _typeOfBaseClass.GetProperty(keyValuePair.Key);
                    MemberExpression objNestedMemberExpression = Expression.Property(xParameter, objClassPropInfo);
                    NewExpression innerObjNew = Expression.New(propertyType);
                    var nestedBindings = keyValuePair.Value.Select(v =>
                    {
                        PropertyInfo nestedObjPropInfo = propertyType.GetProperty(v);
                        MemberExpression nestedOrigin2 = Expression.Property(objNestedMemberExpression, nestedObjPropInfo);
                        var binding2 = Expression.Bind(nestedObjPropInfo, nestedOrigin2);
                        return binding2;
                    });
                    MemberInitExpression nestedInit = Expression.MemberInit(innerObjNew, nestedBindings);
                    shpNestedPropertyBindings.Add(Expression.Bind(objClassPropInfo, nestedInit));
                }
                else
                {
                    Expression mbr = xParameter;
                    mbr = Expression.PropertyOrField(mbr, keyValuePair.Key);
                    PropertyInfo mi = _typeOfBaseClass.GetProperty( ((MemberExpression)mbr).Member.Name );
                    var xOriginal = Expression.Property(xParameter, mi);
                    shpNestedPropertyBindings.Add(Expression.Bind(mi, xOriginal));
                }
            }
            var xInit = Expression.MemberInit(xNew, shpNestedPropertyBindings);
            var lambda = Expression.Lambda<Func<T,T>>( xInit, xParameter );
            return lambda.Compile();
        }
