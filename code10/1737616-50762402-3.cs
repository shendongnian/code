    [TestMethod]
    public void TestMethod()
    {
    	using (var context1 = new SqliteDbContext(new SQLiteConnection(
    			@"C:\db.sqlite"), true
    	))
    	{
    		Console.WriteLine("SQLITE" + Environment.NewLine);
    		Console.Write(context1.SomeTable.FirstOrDefault().SomeRecord);
    		Console.WriteLine(Environment.NewLine);
    	}
    
    	using (var context2 =
    
    		new MsSqlDbContext(
    			new SqlConnection(@"Data Source=localhost;Initial Catalog=SomeDatabase;Integrated Security=True")
    			, true)
    
    		)
    	{
    		Console.WriteLine("MS SQL" + Environment.NewLine);
    		Console.Write(context2.SomeTable.FirstOrDefault().SomeRecord);
    		Console.WriteLine(Environment.NewLine);
    	}
    }
