    public static List<T> Convert<T>(this ExcelWorksheet worksheet) where T : new()
        {
            var result = new List<T>();
            int colCount = worksheet.Dimension.End.Column;  //get Column Count
            int rowCount = worksheet.Dimension.End.Row;
            for (int row = 2; row <= rowCount; row++)
            {
                var obj = new T();
                for (int col = 1; col <= colCount; col++)
                {
                    
                    var value = worksheet.Cells[row, col].Value?.ToString();
                    PropertyInfo propertyInfo = obj.GetType().GetProperty(worksheet.Cells[1, col].Text);
                    propertyInfo.SetValue(obj, Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType), null);
                    
                }
                result.Add(obj);
            }
            return result;
        }
