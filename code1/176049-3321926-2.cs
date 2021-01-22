     DateTime date;
     EnumerableRowCollection<DataRow> query = 
        from order in _table.AsEnumerable()
        select 
       new {
            OrderDate= 
            DateTime.TryParse(Convert.ToString(order.Field<DateTime>("OrderDate")),out date)
             ? date.ToShortDateString() : string.Empty
            }
