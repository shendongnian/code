        private string GetPrimaryKey<K>()
        {
            string primaryKey = string.Empty;
            PropertyInfo[] entityProperties = typeof(K).GetProperties();
            
            foreach (PropertyInfo prop in entityProperties)
            {
                object[] attrs = prop.GetCustomAttributes(false);
                foreach (object obj in attrs)
                {
                    if (obj.GetType() == typeof(PrimaryKeyAttribute))
                    {
                        primaryKey = prop.Name;
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(primaryKey))
                throw new Exception("Cannot determine entity's primary key");
            return primaryKey;
        }
