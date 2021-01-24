    class AircraftFlight
    {
        internal ICollection<ItemFileLink> Files { get; set; }
    }
    class ItemFileLink
    {
        internal int ParentTypeId { get; set; }
    }
    static void Main(string[] args)
    {
        Type aircraftFlightType = typeof(AircraftFlight); 
        Type itemFileLinkType = typeof(ItemFileLink);
        // Create object of desired type
        ParameterExpression aircraftFlightObject = Expression.Parameter(aircraftFlightType, "parameter");
        // Locate files property
        MemberExpression filesPropertyExpression = Expression.Property(aircraftFlightObject, "Files");
        // Getting where method call for Files property
        var whereMethod = new Func<IEnumerable<ItemFileLink>, Func<ItemFileLink, bool>, IEnumerable<ItemFileLink>>(Enumerable.Where);
        // Getting item types and parentId property
        ParameterExpression itemFileLinkExpression = Expression.Parameter(itemFileLinkType);
        Expression parentTypeIdExpression = Expression.Property(itemFileLinkExpression, "ParentTypeId");
        // Create the lambda for where method (your condition for where clause)
        var lambdaForWhere = Expression.Lambda(Expression.Equal(parentTypeIdExpression, Expression.Constant(13)), itemFileLinkExpression);
        // Create where method call
        var whereMethodGeneric = whereMethod.Method.GetGenericMethodDefinition().MakeGenericMethod(itemFileLinkType);
        MethodCallExpression whereCall = Expression.Call(null, whereMethodGeneric, filesPropertyExpression, lambdaForWhere);
        // Create parent object
        AircraftFlight aircraftFlight = new AircraftFlight();
        aircraftFlight.Files = new Collection<ItemFileLink>();
        aircraftFlight.Files.Add(new ItemFileLink { ParentTypeId = 1 });
        aircraftFlight.Files.Add(new ItemFileLink { ParentTypeId = 13 });
        aircraftFlight.Files.Add(new ItemFileLink { ParentTypeId = 1 });
        aircraftFlight.Files.Add(new ItemFileLink { ParentTypeId = 13 });
        aircraftFlight.Files.Add(new ItemFileLink { ParentTypeId = 1 });
        aircraftFlight.Files.Add(new ItemFileLink { ParentTypeId = 1 });
        // Invoke
        var result = Expression.Lambda(whereCall, aircraftFlightObject).Compile().DynamicInvoke(aircraftFlight);
    }
