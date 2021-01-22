        public T As<T>()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            if (type.BaseType != null)
            {
                var properties = type.BaseType.GetProperties();
                foreach (var property in properties)
                    if (property.CanWrite)
                        property.SetValue(instance, property.GetValue(this, null), null);
            }
            return (T) instance;
        }
