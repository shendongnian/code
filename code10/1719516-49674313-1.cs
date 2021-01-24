    public IActionResult SaveForm()
    {
        //If TempData doesn't contains your model then return error message or something.
        if(!TempData.ContainsKey("model"))
            return new HttpNotFoundResult();
        //Retrieve the model from TempData object.
        var formViewModel = TempData["model"] as GikFormViewModel;
        var person = formViewModel.Person;
        var items = formViewModel.Items;
        var gikItems = new Collection<Gikitem>();
        ...
    }
