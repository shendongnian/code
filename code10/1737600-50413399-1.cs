    var c = new C
    {
      A = new A(),
      B = new B()
    }
    var dateTime = DateTime.UtcNow;
    c.UpdateInput(input => input.DateCreated = dateTime);
