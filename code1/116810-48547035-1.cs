    public static class Extensions
    {
    /// <summary>
    /// Converts datatable to list<T> dynamically
    /// </summary>
    /// <typeparam name="T">Class name</typeparam>
    /// <param name="dataTable">data table to convert</param>
    /// <returns>List<T></returns>
    public static List<T> ToList<T>(this DataTable dataTable) where T : new()
    {
        var dataList = new List<T>();
        //Define what attributes to be read from the class
        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
        //Read Attribute Names and Types
        var objFieldNames = typeof(T).GetProperties(flags).Cast<PropertyInfo>().
            Select(item => new
            {
                Name = item.Name,
                Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
            }).ToList();
        //Read Datatable column names and types
        var dtlFieldNames = dataTable.Columns.Cast<DataColumn>().
            Select(item => new {
                Name = item.ColumnName,
                Type = item.DataType
            }).ToList();
        foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
        {
            var classObj = new T();
            foreach (var dtField in dtlFieldNames)
            {
                PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);
                var field = objFieldNames.Find(x => x.Name == dtField.Name);
                if (field != null)
                {
                    if (propertyInfos.PropertyType == typeof(DateTime))
                    {
                        propertyInfos.SetValue
                        (classObj, ConvertToDateTime(dataRow[dtField.Name]), null);
                    }
                    else if (propertyInfos.PropertyType == typeof(int))
                    {
                        propertyInfos.SetValue
                        (classObj, ConvertToInt(dataRow[dtField.Name]), null);
                    }
                    else if (propertyInfos.PropertyType == typeof(long))
                    {
                        propertyInfos.SetValue
                        (classObj, ConvertToLong(dataRow[dtField.Name]), null);
                    }
                    else if (propertyInfos.PropertyType == typeof(decimal))
                    {
                        propertyInfos.SetValue
                        (classObj, ConvertToDecimal(dataRow[dtField.Name]), null);
                    }
                    else if (propertyInfos.PropertyType == typeof(String))
                    {
                        if (dataRow[dtField.Name].GetType() == typeof(DateTime))
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertToDateString(dataRow[dtField.Name]), null);
                        }
                        else
                        {
                            propertyInfos.SetValue
                            (classObj, ConvertToString(dataRow[dtField.Name]), null);
                        }
                    }
                }
            }
            dataList.Add(classObj);
        }
        return dataList;
    }
    private static string ConvertToDateString(object date)
    {
        if (date == null)
            return string.Empty;
        return HelperFunctions.ConvertDate(Convert.ToDateTime(date));
    }
    private static string ConvertToString(object value)
    {
        return Convert.ToString(HelperFunctions.ReturnEmptyIfNull(value));
    }
    private static int ConvertToInt(object value)
    {
        return Convert.ToInt32(HelperFunctions.ReturnZeroIfNull(value));
    }
    private static long ConvertToLong(object value)
    {
        return Convert.ToInt64(HelperFunctions.ReturnZeroIfNull(value));
    }
    private static decimal ConvertToDecimal(object value)
    {
        return Convert.ToDecimal(HelperFunctions.ReturnZeroIfNull(value));
    }
    private static DateTime ConvertToDateTime(object date)
    {
        return Convert.ToDateTime(HelperFunctions.ReturnDateTimeMinIfNull(date));
    }
    }
    public static class HelperFunctions
    {
    public static object ReturnEmptyIfNull(this object value)
    {
        if (value == DBNull.Value)
            return string.Empty;
        if (value == null)
            return string.Empty;
        return value;
    }
    public static object ReturnZeroIfNull(this object value)
    {
        if (value == DBNull.Value)
            return 0;
        if (value == null)
            return 0;
        return value;
    }
    public static object ReturnDateTimeMinIfNull(this object value)
    {
        if (value == DBNull.Value)
            return DateTime.MinValue;
        if (value == null)
            return DateTime.MinValue;
        return value;
    }
    /// <summary>
    /// Convert DateTime to string
    /// </summary>
    /// <param name="datetTime"></param>
    /// <param name="excludeHoursAndMinutes">if true it will execlude time from datetime string. Default is false</param>
    /// <returns></returns>
    public static string ConvertDate(this DateTime datetTime, bool excludeHoursAndMinutes = false)
    {
        if (datetTime != DateTime.MinValue)
        {
            if (excludeHoursAndMinutes)
                return datetTime.ToString("yyyy-MM-dd");
            return datetTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        return null;
    }
    }
