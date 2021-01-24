    class TestProfile : Profile
    {
        public TestProfile()
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            Func<PropertyInfo, bool> filter = p => p.CanRead && p.CanWrite;
            var outerProperties = typeof(Outer).GetProperties(flags).Where(filter).ToDictionary(p => p.Name);
            var innerProperties = typeof(Inner).GetProperties(flags).Where(filter);
            var mappingProperties = innerProperties.Where(p => !outerProperties.ContainsKey(p.Name));
            //code above gets the properties of Inner that needs to be mapped
            var outerParameter = Expression.Parameter(typeof(Outer));
            var accessBar = Expression.Property(outerParameter, nameof(Outer.Bar));
            var map = CreateMap<Outer, FlatDto>();
            var mapExp = Expression.Constant(map);
            
            foreach (var property in mappingProperties)
            {
                var accessProperty = Expression.MakeMemberAccess(accessBar, property);
                var funcType = typeof(Func<,>).MakeGenericType(typeof(Outer), property.PropertyType);
                var funcExp = Expression.Lambda(funcType, accessProperty, outerParameter);
                //above code builds s => s.Bar.Qux
                var configType = typeof(IMemberConfigurationExpression<,,>).MakeGenericType(typeof(Outer), typeof(FlatDto), typeof(object));
                var configParameter = Expression.Parameter(configType);
                var mapFromMethod = configType
                    .GetMethods()
                    .Single(m => m.Name == "MapFrom" && m.IsGenericMethod)
                    .MakeGenericMethod(property.PropertyType);
                var invokeMapFrom = Expression.Call(configParameter, mapFromMethod, funcExp);
                var configExp = Expression.Lambda(typeof(Action<>).MakeGenericType(configType), invokeMapFrom, configParameter);
                //above code builds opt => opt.MapFrom(s => s.Bar.Qux)
                var forMemberMethod = map.GetType()
                    .GetMethods()
                    .Single(m => m.Name == "ForMember" && !m.IsGenericMethod);
                var invokeForMember = Expression.Call(mapExp, forMemberMethod, Expression.Constant(property.Name), configExp);
                //above code builds map.ForMember("Qux", opt => opt.MapFrom(s => s.Bar.Qux))
                var configAction = Expression.Lambda<Action>(invokeForMember);
                configAction.Compile().Invoke();
            }
        }
    }
