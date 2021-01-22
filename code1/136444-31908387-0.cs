    public ActionResult MyAction(MyViewModel vm)
    {
        // perform conditional test
        // if true, then remove from ModelState (e.g. ModelState.Remove("MyKey")
        // Do typical model state validation, inside following if:
        //     if (!ModelState.IsValid)
        // Do rest of logic (e.g. fetching, saving
