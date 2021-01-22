    public ActionResult Software(string language, int id)
    {
      //GetSoftware will now go off to the db and get the model based on the language provided to it.
      MyModel model = ProductService.GetSoftware(language, id);
      return View(model);
    }
