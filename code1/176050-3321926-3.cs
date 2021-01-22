     DateTime date;
     EnumerableRowCollection<DataRow> query = 
 
        from order in _table.AsEnumerable()
        select 
       new {
            OrderDate= 
            string.IsNullorEmpty(Convert.ToString(order.Field<DateTime>("OrderDate"))
            || 
            !DateTime.TryParse(Convert.ToString(order.Field<DateTime>("OrderDate")),out date)
             ? string.Empty : date.ToShortDateString() 
            }
