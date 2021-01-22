    public Func<string> PropertyGetter{ get; set; }
    public string Property{ 
       get{
           return PropertyGetter();
          }
    }
