        public Derived(Base item) :base()
        {
            Type type = item.GetType();
            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                try
                {
                    property.SetValue(this, property.GetValue(item, null), null);
                }
                catch (Exception) { }
            }
        }
