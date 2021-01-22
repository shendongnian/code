    [AcceptVerbs(HttpVerbs.Get)]
    public ViewResult Edit() {
     var model = new ViewModel1 {
       PossibleValues = GetDictionary()  //populate your Dictionary here
     };
     return View(model);
    }
    [AcceptVerbs(HttpVerbs.Post)]
    public ViewResult Edit(ViewModel1 model) { //default model binding
      model.PossibleValues = GetDictionary();  //repopulate your Dictionary here
      return View(model);
    }
