        DataTable yourTable = new DataTable();
       
        //This is the important step
        // add a ColumnChanged event handler for the table.
        custTable.ColumnChanged += new 
            DataColumnChangeEventHandler(Column_Changed );
