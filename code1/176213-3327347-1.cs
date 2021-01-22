    using(MyDataContext dc = new MyDataContext("ConnectionString"))
    {
      foreach(var foo in dc.foo2)
      {
       foo.prop1 = 1;
      }
      dc.SubmitChanges();
    }
