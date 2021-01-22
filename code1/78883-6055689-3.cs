    public static DataTable ToDataTable<T>(this IEnumerable<T> items) 
        where T: class
    {  
        // ... create table the same way
        var propGetters = new List<Func<T, object>>();
	foreach (var prop in props)
        {
            Func<T, object> func = (Func<T, object>) ReflectionUtility.GetGetter(prop);
            propGetters.Add(func);
        }
    
        // Add the property values per T as rows to the datatable
        foreach (var item in items) 
        {  
            var values = new object[props.Length];  
            for (var i = 0; i < props.Length; i++) 
            {
                //values[i] = props[i].GetValue(item, null);   
                values[i] = propGetters[i](item);
            }    
            table.Rows.Add(values);  
        } 
    
        return table; 
    } 
