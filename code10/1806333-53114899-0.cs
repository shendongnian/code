    listView.View = View.Details;
    listView.Columns.Add ( "Name" );
    listView.Columns.Add ( "Address" );
    listView.Columns.Add ( "Age" );
    listView.Columns.Add ( "Gross Pay" );
    listView.Columns.Add ( "Division" );
    List<string> data = File.ReadAllLines ( "TestCSV.txt" ).ToList ( );
    foreach(string d in data)
    {
        string[] items = d.Split(new char[] {','}, 
               StringSplitOptions.RemoveEmptyEntries);
         listView.Items.Add ( new ListViewItem ( items ) );                
    }
