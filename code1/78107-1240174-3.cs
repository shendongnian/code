        public void Test ()
        {
            var obj = new Foo2() { Prop1 = "Test", Prop2 = "Test2" };
            SerializeGeneric(ShallowCopy<Foo1>(obj));
        }
        private T ShallowCopy<T>(object input)
            where T : class, new()
        {
            T newObj = Activator.CreateInstance<T>();
            Type oldType = input.GetType();
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField | BindingFlags.SetField;
            var oldProperties = oldType.GetProperties(flags);
            foreach (var pd in typeof(T).GetProperties(flags))
            {
                var oldPd = oldProperties.FirstOrDefault(x=>x.Name == pd.Name && x.PropertyType == pd.PropertyType);
                pd.SetValue(newObj, oldPd.GetValue(input, null), null);
            }
            return newObj;
        }
