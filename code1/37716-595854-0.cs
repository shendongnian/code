    public ActionResult Edit( int id )
    {
          Person person = peopleService.GetPerson(id);
          UpdateModel(person,new string[] { list of properties to update } );
          peopleService.SavePerson(person);
          ...
    }
