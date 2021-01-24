    var c = new C
    {
      A = new A(),
      B = new B()
    }
    //this is ugly and what we want to avoid
    c.A.DateCreated = DateTime.Now;
    c.B.DateCreated = DateTime.Now;
