    Public ActionResult EditThing(int ID)
    {
        ThingRepository repository = new ThingRepository();
        If (!repository.UserHasAccess(int ID))
           Return View("NotAuthorized")
        //
        // Do stuff here
    }
