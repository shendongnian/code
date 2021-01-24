    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Example(Example model)
    {
        ModelState.Clear(); 
        model.Text += "a";
        return View(model);
    }
