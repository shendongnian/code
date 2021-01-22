    public MockDB_Access : IDB_Access
    {
      public const string MY_NAME = "SomeName;
      public Hashtable GetAgentFromDatabase(int agentId)
      {  var hash = new Hashtable();
         hash["FirstName"] = MY_NAME; // fill other properties as well
         return hash;
      }
    }
    
    // in the unit test
    var testSubject = new NoName( new MockDB_Access() );
    var agent = testSubject.Select(1);
    Assert.AreEqual(MockDB_Access.MY_NAME, agent.FirstName); // and so on...
