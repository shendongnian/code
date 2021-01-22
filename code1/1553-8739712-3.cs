    //Create DataTable 
    DataTable dt= new DataTable();
    dt.Columns.AddRange(New DataColumn[]
    {
       new DataColumn("ID",typeOf(System.Int32)),
       new DataColumn("Name",typeOf(System.String))
    
    });
    
    //Fill with data
    
    dt.Rows.Add(new Object[]{1,"Test1"});
    dt.Rows.Add(new Object[]{2,"Test2"});
    
    //Now  Query DataTable with linq
    //To work with linq it should required our source implement IEnumerable interface.
    //But DataTable not Implement IEnumerable interface
    //So we call DataTable Extension method  i.e AsEnumerable() this will return EnumerableRowCollection<DataRow>
    
    
    // Now Query DataTable to find Row whoes ID=1
    
    DataRow drow = dt.AsEnumerable().Where(p=>p.Field<Int32>(0)==1).FirstOrDefault();
     // 
