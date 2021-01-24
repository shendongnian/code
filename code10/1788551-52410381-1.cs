    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Example(Example model)
    {
        var newValue = model.Text += "a";
        ModelState["Text"].Value = new ValueProviderResult(newValue,newValue, CultureInfo.CurrentCulture)
        return View(model);
    }
