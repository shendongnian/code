    public int Foo
    {
       [SecurityPermission(...)]
       get
       {
          return GetFoo();
       }
    
       [SecurityPermission(...)]
       set
       {
          SetFoo(value);
       }
    }
