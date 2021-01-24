    [HttpPost]
    public IActionResult AddResult(MyViewModel o)
    {
        return RedirectToAction(nameof(About));
    }
