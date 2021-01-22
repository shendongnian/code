    // POST: /YourController/YourAction/{ID}
    [HttpPost]
    public ActionResult YourAction(YourModel model, int id)
    {
        // model.StateProvinceId has the selected value
        
        // you need to fill StateProvinces since it is empty as the list is not posted
        // back so it is not autofilled into your model.
        model.StateProvinces = LoadYourStateProvincesList();
        // This would blow up if StateProvinces is null because your View is assuming that
        // it has a valid list of StateProvinces in it to build the DropDown
        return View(model);
    }
