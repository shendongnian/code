    public ActionResult Create()
    {
      YourEntities entities = new YourEntities();
      List<Department> departments = entities.DepartmentSet.ToList();
      PersonFormViewModel viewModel = 
        new PersonFormViewModel(new Person(), departments);
      return View(modelView);
    }    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create([Bind(Exclude="Id")]Person personToCreate
    {
      YourEntities entities = new YourEntities(); // Probably not instantiated here
      entities.AddToPersonSet(personToCreate);
      entities.SaveChanges();
      redirectToAction("Index");
    }
