    public IActionResult Visitors()
    {
        VisitorTypes = _db.VisitorTypes.ToList();
        return View(VisitorTypes);
    }
