    class MyClass
    {
      private Bar _bar = new Bar();
      [JsonIgnore]
      public Foo Foo
      {
         get { return Bar.Foo; }
         set { Bar.Foo = value; }
      }
    
      [JsonProperty("bar")]
      private Bar Bar
      {
        get
        {
          // there's some validation logic that goes here
          return _bar;
        }
        set
        {
          _bar = value;
        }
      }
    }
