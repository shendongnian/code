    [HttpPost]
    public ActionResult Edit(int id, Series series)
    {
        Series updatingSeries = model.Series.Single(s => s.ID == id);
        try
        {
            TryUpdateModel(updatingSeries);
            model.SubmitChanges();
            return RedirectToAction("Details", new { id = updatingSeries.ID });
        }
        catch
        {
            return View(updatingSeries);
        }
    }
