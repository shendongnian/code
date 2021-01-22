    class Client
    {
       public string Name {get; set;}
       public override ToString()
       { 
        return Name;
       }
    }
    class MyClass
    {
       public DateTime Date {get; set;}
       public Client MyClient {get; set;}
       public override ToString()
       { 
        return string.Format("Client: {0}; Date: {1}", MyClient, Date);
       }
    }
