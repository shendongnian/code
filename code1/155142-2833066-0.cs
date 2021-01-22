    [HttpPost()]
    public void Update(BaseItem item)
    {
        if (item is IActionItem)
            RedirectToAction("List");
        else
            // do something else
    }
