    public static void CallingFooBar()
    {
       using (var ts=new TransactionScope())
       {
          var foo=new Foo();
          foo.Bar();
          ts.Complete();
       }
    }
