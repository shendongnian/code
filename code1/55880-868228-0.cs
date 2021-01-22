    GridView myGridView = new GridView();
    myGridView.AllowsColumnReorder = true; 
    myGridView.ColumnHeaderToolTip = "Employee Information";
    
    GridViewColumn gvc1 = new GridViewColumn();
    gvc1.DisplayMemberBinding = new Binding("FirstName");
    gvc1.Header = "FirstName";
    gvc1.Width = 100;
    myGridView.Columns.Add(gvc1);
    GridViewColumn gvc2 = new GridViewColumn();
    gvc2.DisplayMemberBinding = new Binding("LastName");
    gvc2.Header = "Last Name";
    gvc2.Width = 100;
    myGridView.Columns.Add(gvc2);
    GridViewColumn gvc3 = new GridViewColumn();
    gvc3.DisplayMemberBinding = new Binding("EmployeeNumber");
    gvc3.Header = "Employee No.";
    gvc3.Width = 100;
    myGridView.Columns.Add(gvc3);
    
    listView.View = myGridView;
