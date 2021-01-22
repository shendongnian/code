        public AnyObject(AnyObject anyObject)
        {
            foreach (var property in typeof(AnyObject).GetProperties())
            {
                property.SetValue(this, property.GetValue(anyObject));
            }
            foreach (var field in typeof(AnyObject).GetFields())
            {
                field.SetValue(this, field.GetValue(anyObject));
            }
        }
