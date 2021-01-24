    [AttributeUsage(AttributeTargets.Property)]
    public class SLSqlTableAttribute : Attribute
    {
        protected string _fieldName { get; set; }
        public string FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }
        public SLSqlTableAttribute(string fieldName)
        {
            FieldName = fieldName;
        }     
    }
    public class SourceTargetProperties
    {
        public PropertyInfo SourceProperty { get; set; }
        public PropertyInfo TargetProperty { get; set; }
    }
    public static class DataMapper
    {
        static Dictionary<string, List<SourceTargetProperties>> _dictTypeProperties = new Dictionary<string, List<SourceTargetProperties>>();
        public static void CopyToSqlProperties(object source, object target, int? userId, DateTimeOffset? modifiedDateTime, bool isInsert)
        {
            Type _typeTarget = target.GetType();
            Type _typeSrc = source.GetType();
            // If we're passed in a collection
            if (_typeSrc.GetInterfaces().Any(a => a.Name == "IEnumerable") && _typeSrc.IsGenericType && _typeTarget.IsGenericType)
            {
                dynamic _sourceList = source;
                foreach (var _source in _sourceList)
                {
                    object _tempTarget = Activator.CreateInstance(_typeTarget.GetGenericArguments()[0]);
                    CopyToModelProperties(_source, _tempTarget);
                    // here we have to make recursive call to copy data and populate the target list.
                    //_targetList.Add(CopyObjectPropertyData(_source, (dynamic)new object()));
                    //  _newtargetList.GetType().GetMethod("Add").Invoke(_newtargetList, new[] { _tempTarget });
                    target.GetType().GetMethod("Add").Invoke(target, new[] { _tempTarget });
                }
            }
            else
            {
                // Collect all the valid properties to map
                if (!_dictTypeProperties.ContainsKey(_typeSrc.BaseType.Name))
                {
                    _dictTypeProperties.Add(_typeSrc.BaseType.Name, (from srcProp in _typeSrc.GetProperties()
                                                                     let targetProperty = _typeTarget.GetProperty(GetModelPropertyNameFromSqlAttribute(_typeTarget, srcProp.Name))
                                                                     where srcProp.CanRead
                                                                     && targetProperty != null
                                                                     && (targetProperty.GetSetMethod(true) != null && !targetProperty.GetSetMethod(true).IsPrivate)
                                                                     && (targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) == 0
                                                                     //  && targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType)
                                                                     select new SourceTargetProperties { SourceProperty = srcProp, TargetProperty = targetProperty }).ToList());
                }
                foreach (var prop in _dictTypeProperties[_typeSrc.BaseType.Name])
                {
                    if (prop.TargetProperty.CanWrite && prop.SourceProperty.CanRead)
                    {
                        object targetValue = prop.TargetProperty.GetValue(target, null);
                        object sourceValue = prop.SourceProperty.GetValue(source, null);
                        if (sourceValue == null) { continue; }
                        //if (prop.sourceProperty.PropertyType.IsArray
                        //    && prop.targetProperty.PropertyType.IsArray
                        //    && sourceValue != null)
                        if (prop.SourceProperty.PropertyType.IsClass && prop.TargetProperty.PropertyType != typeof(string))
                        {
                            var destinationClass = Activator.CreateInstance(prop.TargetProperty.PropertyType);
                            object copyValue = prop.SourceProperty.GetValue(source);
                            CopyToModelProperties(copyValue, destinationClass);
                            prop.TargetProperty.SetValue(target, destinationClass);
                        }// See if there is a better way to do this.
                        else if (prop.TargetProperty.PropertyType.GetInterfaces().Any(a => a.Name == "IEnumerable") && prop.SourceProperty.PropertyType.IsGenericType
                            && prop.TargetProperty.PropertyType.IsGenericType
                            && sourceValue != null)
                        {
                            CopyToModelList(source, target, prop.TargetProperty, prop.SourceProperty, sourceValue);
                        }
                        else
                        {
                            string _targetPropertyName = prop.TargetProperty.Name;
                            if (modifiedDateTime.HasValue && (_targetPropertyName == "CreatedDateTime" || _targetPropertyName == "LastModifiedDateTime" || _targetPropertyName == "CreatedBy" ||
                             _targetPropertyName == "LastModifiedBy"))
                            {
                                switch (_targetPropertyName)
                                {
                                    case "CreatedDateTime":
                                        if (isInsert)
                                        {
                                            prop.TargetProperty.SetValue(target, modifiedDateTime, null);
                                        }
                                        break;
                                    case "CreatedBy":
                                        if (isInsert)
                                        {
                                            prop.TargetProperty.SetValue(target, userId, null);
                                        }
                                        break;
                                    case "LastModifiedDateTime":
                                        prop.TargetProperty.SetValue(target, modifiedDateTime, null);
                                        break;
                                    case "LastModifiedBy":
                                        prop.TargetProperty.SetValue(target, userId, null);
                                        break;
                                }
                            }
                            else
                            {
                                prop.TargetProperty.SetValue(target, prop.SourceProperty.GetValue(source, null), null);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        ///  Copy from SQL EF Entities to our Models.
        ///  Models will have the sql table name as a SLSqlAttribute for this to work.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static void CopyToModelProperties(object source, object target)
        {
            Type _typeTarget = target.GetType();
            Type _typeSrc = source.GetType();
            if (_typeSrc.GetInterfaces().Any(a => a.Name == "IEnumerable") && _typeSrc.IsGenericType && _typeTarget.IsGenericType)
            {
                // figure out a way to take in collections here instead of having to loop through outside of code.
                //  int _sourceLength = (int)source.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, source, null);
                var _listType = typeof(List<>);
                //var _genericArgs = props.sourceProperty.PropertyType.GetGenericArguments();
                //var _genericTargetArgs = _typeTarget.GetGenericArguments();
                //var _concreteTargetType = _listType.MakeGenericType(_genericTargetArgs);
                //var _newtargetList = Activator.CreateInstance(_concreteTargetType);
                //_newtargetList = piSource.GetValue(source, null);
                //var _genericTargetArgs
                dynamic _sourceList = source;
                //dynamic _sourceList = _typeSrc.GetValue(source, null);
                //    dynamic _targetList = piTarget.GetValue(target, null);
                foreach (var _source in _sourceList)
                {
                    object _tempTarget = Activator.CreateInstance(_typeTarget.GetGenericArguments()[0]);
                    CopyToModelProperties(_source, _tempTarget);
                    // here we have to make recursive call to copy data and populate the target list.
                    //_targetList.Add(CopyObjectPropertyData(_source, (dynamic)new object()));
                    //  _newtargetList.GetType().GetMethod("Add").Invoke(_newtargetList, new[] { _tempTarget });
                    target.GetType().GetMethod("Add").Invoke(target, new[] { _tempTarget });
                }
                //   _typeTarget.SetValue(target, _newtargetList, null);
            }
            else
            {
                // Collect all the valid properties to map
                if (!_dictTypeProperties.ContainsKey(_typeSrc.BaseType.Name))
                {
                    _dictTypeProperties.Add(_typeSrc.BaseType.Name, (from srcProp in _typeSrc.GetProperties()
                                                                     let targetProperty = _typeTarget.GetProperty(GetModelPropertyNameFromSqlAttribute(_typeTarget, srcProp.Name))
                                                                     where srcProp.CanRead
                                                                     && targetProperty != null
                                                                     && (targetProperty.GetSetMethod(true) != null && !targetProperty.GetSetMethod(true).IsPrivate)
                                                                     && (targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) == 0
                                                                     //  && targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType)
                                                                     select new SourceTargetProperties { SourceProperty = srcProp, TargetProperty = targetProperty }).ToList());
                }
                foreach (var prop in _dictTypeProperties[_typeSrc.BaseType.Name])
                {
                    if (prop.TargetProperty.CanWrite && prop.SourceProperty.CanRead)
                    {
                        object targetValue = prop.TargetProperty.GetValue(target, null);
                        object sourceValue = prop.SourceProperty.GetValue(source, null);
                        if (sourceValue == null) { continue; }
                        //if (prop.sourceProperty.PropertyType.IsArray
                        //    && prop.targetProperty.PropertyType.IsArray
                        //    && sourceValue != null)
                        if (prop.SourceProperty.PropertyType.IsClass && prop.TargetProperty.PropertyType != typeof(string))
                        {
                            var destinationClass = Activator.CreateInstance(prop.TargetProperty.PropertyType);
                            object copyValue = prop.SourceProperty.GetValue(source);
                            CopyToModelProperties(copyValue, destinationClass);
                            prop.TargetProperty.SetValue(target, destinationClass);
                        }// See if there is a better way to do this.
                        else if (prop.TargetProperty.PropertyType.GetInterfaces().Any(a => a.Name == "IEnumerable") && prop.SourceProperty.PropertyType.IsGenericType
                            && prop.TargetProperty.PropertyType.IsGenericType
                            && sourceValue != null)
                        {
                            CopyToModelList(source, target, prop.TargetProperty, prop.SourceProperty, sourceValue);
                        }
                        else
                        {
                            string _targetPropertyName = prop.TargetProperty.Name;
                            prop.TargetProperty.SetValue(target, prop.SourceProperty.GetValue(source, null), null);
                        }
                    }
                }
            }
            // return target;
        }
        public static string GetModelPropertyNameFromSqlAttribute(Type model, string sqlName)
        {
            string _ret = "";
            var _property = model.GetProperties().Where(w => w.GetCustomAttributes<SLSqlTableAttribute>().Where(w1 => w1.FieldName == sqlName).Any()).FirstOrDefault();
            if (_property != null)
            {
                _ret = _property.Name;
            }
            return _ret;
        }
        private static void CopyToModelList(object source, object target, PropertyInfo piTarget, PropertyInfo piSource, object sourceValue)
        {
            //  int _sourceLength = (int)source.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, source, null);
            // First create a generic collection that matches the piTarget being passed in.
            var _listType = typeof(List<>);
            //var _genericArgs = props.sourceProperty.PropertyType.GetGenericArguments();
            var _genericTargetArgs = piTarget.PropertyType.GetGenericArguments();
            var _concreteTargetType = _listType.MakeGenericType(_genericTargetArgs);
            var _newtargetList = Activator.CreateInstance(_concreteTargetType);
            //_newtargetList = piSource.GetValue(source, null);
            //var _genericTargetArgs
            dynamic _sourceList = piSource.GetValue(source, null);
            //    dynamic _targetList = piTarget.GetValue(target, null);
            foreach (var _source in _sourceList)
            {
                object _tempTarget = Activator.CreateInstance(piTarget.PropertyType.GetGenericArguments()[0]);
                CopyToModelProperties(_source, _tempTarget);
                // here we have to make recursive call to copy data and populate the target list.
                //_targetList.Add(CopyObjectPropertyData(_source, (dynamic)new object()));
                _newtargetList.GetType().GetMethod("Add").Invoke(_newtargetList, new[] { _tempTarget });
            }
            piTarget.SetValue(target, _newtargetList, null);
        }
    }
