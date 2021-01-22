    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            T tempT = new T();
            var tType = tempT.GetType();
            List<T> list = new List<T>();
            foreach (var row in table.Rows.Cast<DataRow>())
            {
                var propertyInfo = tType.GetProperty(prop.Name);
                var rowValue = row[prop.Name];
                var t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                try
                {
                    object safeValue = (rowValue == null || DBNull.Value.Equals(rowValue)) ? null : Convert.ChangeType(rowValue, t);
                    propertyInfo.SetValue(obj, safeValue, null);
                    }
                    catch (Exception ex)
                    {//this write exception to my logger
                       _logger.Error(ex.Message);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        catch
        {
            return null;
        }
    }
