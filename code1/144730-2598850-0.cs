    // read only interface
    interface IC
    {
      int IssueNumber { get; }
    }
    class C : IC
    {
      int IssueNumber { get; set; }
    }
    
    // get the full type from A
    class A
    {
      C MyClassC { get; }
    }
    
    // only get read only interface from B
    class B
    {
      IC MyClassC { get; }
    }
