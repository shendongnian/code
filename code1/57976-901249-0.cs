    public ActionResult ShowAddress(FormCollection formCollection) {
      if ( null == formCollection ) { 
        return View();
      }
      object obj = formCollection["UserId"];
      if ( null == obj ) {  
        return View();
      }
      long _userId = long.Parse(obj.ToString());
      ...
    }
