     // Create fake (stub/mock whateever) objects
     var fakeSqlConnection = Isolate.Fake.Instance<SqlConnection>();
     var fakeCommand = Isolate.Fake.Instance<SqlCommand>();
     Isolate.WhenCalled(() => fakeSqlConnection.CreateCommand()).WillReturn(fakeCommand);
    
     var fakeReader = Isolate.Fake.Instance<SqlDataReader>();
     Isolate.WhenCalled(() => fakeCommand.ExecuteReader()).WillReturn(fakeReader);
     
     // Next time SQLConnection is instantiated replace with our fake
     Isolate.Swap.NextInstance<SqlConnection>().With(fakeSqlConnection);
