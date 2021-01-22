    using (IDataReader myReader = DataFunctions.ExecuteReader(CommandType.Text, sql.ToString(), dp.Parameters, myConnectionString)) 
    {
        while (myReader.Read()) 
        {
            MyObject theObject = new MyObject();
            theObject.PublicProperty = myReader.GetString(0);
            myCollection.Add(theObject);
        }
    }
