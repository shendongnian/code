    public void InitializeListView()
    {
    ColumnHeader header1 = this.listView1.InsertColumn(0, "Name", 10*listView1.Font.SizeInPoints.ToInt32() , HorizontalAlignment.Center);
    ColumnHeader header2 = this.listView1.InsertColumn(1, "E-mail", 20*listView1.Font.SizeInPoints.ToInt32(), HorizontalAlignment.Center);
    ColumnHeader header3 = this.listView1.InsertColumn(2, "Phone", 20*listView1.Font.SizeInPoints.ToInt32(), HorizontalAlignment.Center );
    } 
