     DateTime stubDate;
     EnumerableRowCollection<DataRow> query = 
        from order in _table.AsEnumerable()
        select 
       new {
            OrderDate= 
            string.IsNullorEmpty(Convert.ToString(order.Field<DateTime>("OrderDate")))
            || 
            !DateTime.TryParse(Convert.ToString(order.Field<DateTime>("OrderDate")),out stubDate)
             ? String.Empty : order.Field<DateTime>("OrderDate") 
            }
