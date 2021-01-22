            builder.RegisterGeneric(typeof (FakeRepository<>)).As(typeof (IRepository<>)).OnActivating(e =>
            {
                var typeToLookup = e.Parameters.FirstOrDefault() as TypedParameter;
                if (typeToLookup != null)
                {
                    var respositoryType = typeof (FakeRepository<>);
                    Type[] typeArgs = {typeToLookup.Value.GetType()};
                    var genericType = respositoryType.MakeGenericType(typeArgs);
                    var genericRepository = Activator.CreateInstance(genericType);
                    e.ReplaceInstance(genericRepository);
                }
            });
