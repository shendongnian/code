    List<Test> TestList = new List<Test>();
    Test test;
    
    while (reader.Read())
    {
        test = new Test();
        test.ID = int.Parse(reader["ID"].ToString());
        test.Name = reader["Name"].ToString();
        TestList.Add(test);
    }
    
    gvGrid.DataSource = TestList;
    gvGrid.DataBind(); 
