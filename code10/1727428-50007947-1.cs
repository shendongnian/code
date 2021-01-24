      SqlConection con=new SqlConnection("connection string here")
      SqlCommand cmd = new SqlCommand("Select * from table",con)
      SqlDatareader dr = cmd.ExecuteReader();
      While (dr.Read())
       {
        MyDatarow row = new MyDatarow;
        If (row.ItemHolder.ColumnDefinition.Count = 0)
         {
           row.ItemHolder.ColumnDefinition.Add(new ColumnDefinition)//this will ad required number of columns which will represent the cells
         }     
        TextBox txtbx = new TextBox;
        txtbx.Height = 20
        row.ItemHolder.Children.Add(txtbx)
        Grid.SetColumn(txtbx,1) /// here 1 is the column count, change it as you want :)
        MyDatagrid.Childer.Add(row);
        MyDatagrid.height = MyDatagrid.height + 30 ;
       }
