    public ActionResult Software(string language, int id)
    {
      //This would go off to the DAL and get the content in whatever language you want.
      ProductModel model = ProductService.GetSoftware(language, id);
      return View(model);
    }
