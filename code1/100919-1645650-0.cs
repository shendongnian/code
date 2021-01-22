    Status status = Status.Error;
    try {
      var res1 = performStep1(); 
      status = Status.Warning;
      performStep2(res1);
      status = Status.Whatever
      performStep3();
      status = Status.Success; // no exceptions thrown
    } catch (Exception ex) {
      log(ex);
    } finally {
     // ...
    }
