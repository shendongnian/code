            int _x = 0;
            int _y = 0;
            
            Type t = e.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(t.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == "X")
                {
                    object propValue = prop.GetValue(e, null);
                    _x = Convert.ToInt32(propValue);
                }
                if (prop.Name == "Y")
                {
                    object propValue = prop.GetValue(e, null);
                    _y = Convert.ToInt32(propValue);
                }
            }
