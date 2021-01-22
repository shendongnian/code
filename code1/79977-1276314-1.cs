    fTable.ColumnChanged += new DataColumnChangeEventHandler(delegate(object sender, DataColumnChangeEventArgs e)
    {
       Console.WriteLine(e.Column.ColumnName);
    }
    );
 
