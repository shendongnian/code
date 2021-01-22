        public static class FactoryMethod<T>  where T : IModelInput, new()
        {
            public static IModelInput Create()
            {
                return new T();
            }
        }
        delegate IModelInput ModelInputCreateFunction();
        IModelInput CreateIModelInput(object item)
        {
            Dictionary<Type, ModelInputCreateFunction> factory = new Dictionary<Type, ModelInputCreateFunction>();
            
            
            factory.Add(typeof(Rectangle), FactoryMethod<Foo>.Create);
            factory.Add(typeof(Circle),    FactoryMethod<Bar>.Create);
            // Add more type mappings here
            IModelInput modelInput;
            foreach (Type t in factory.Keys)
            {
                if ( item.GetType().IsSubclassOf(t) || item.GetType().Equals(t))
                {
                    modelInput = factory[t].Invoke();
                    break;
                }
            }
            return modelInput;
        }
