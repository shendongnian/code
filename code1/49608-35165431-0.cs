        while (reader.Read()) {
            string[] columns = reader.CurrentRecord;
            CdsRawPayfileEntry toAdd = new CdsRawPayfileEntry();
            IEnumerable<PropertyInfo> rawPayFileAttributes = typeof(CdsRawPayfileEntry).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(CustomIndexAttribute)));
            foreach (var property in rawPayFileAttributes) {
                int propertyIndex = ((CustomIndexAttribute)property.GetCustomAttribute(typeof(CustomIndexAttribute))).Index;
                if (propertyIndex < columns.Length)
                    property.SetValue(toReturn, columns[propertyIndex]);
                else
                    break;
            }
        }
