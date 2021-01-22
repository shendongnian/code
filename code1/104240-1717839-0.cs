    public class Foo
    {
    public string FullName { get;set; } 
    public string Summary {get;set; }
    
    public Foo(fullName,summary)
    {
      FullName=fullName;
      Summary=summary;
    }
    }
    /// elsewhere...
    List<Foo> myFoos = new List<Foo>();
    myFoos.Add(new Foo("Alice","Some chick"));
    myFoos.Add(new Foo("Bob","Some guy"));
    myFoos.Add(new Foo("Charlie","Indeterminate"));
    Repeater1.DataSource = myFoos;
    Repeater1.DataBind();
