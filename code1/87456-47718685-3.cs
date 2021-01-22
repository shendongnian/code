    public Item()
        {
            foreach (var pinfo in GetType().GetProperties())
            {
                object value = 0;
                var response = ReflectionHelpers.TryChangeType(value, pinfo.PropertyType);
                if(response.IsSuccess)
                {
                    pinfo.SetValue(this, response.Value);
                }
            }
        }
