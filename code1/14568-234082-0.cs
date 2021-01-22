        public Dictionary<Type, object> GenerateLists(List<Type> types)
        {
            Dictionary<Type, object> lists = new Dictionary<Type, object>();
            foreach (Type type in types)
            {
                if (!delegates.ContainsKey(type))
                    delegates.Add(type, CreateListDelegate(type));
                lists.Add(type, delegates[type]());
            }
            return lists;
        }
        private Func<object> CreateListDelegate(Type type)
        {
            MethodInfo createListMethod = GetType().GetMethod("CreateList");
            MethodInfo genericCreateListMethod = createListMethod.MakeGenericMethod(type);
            return Delegate.CreateDelegate(typeof(Func<object>), this, genericCreateListMethod) as Func<object>;
        }
        public object CreateList<T>()
        {
            return new List<T>();
        }
