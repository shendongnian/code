       public string GetColumnValue(string columnName)
        {
            object value = item[columnName];
            if (value == null)
                return string.Empty;
            
            return object.ToString();
        }
