    [HttpPost]
    ActionResult MyAction(IList<MyObject> objects)
    {
        foreach (MyObject obj in objects)
        {
            if (obj.Checked)
            {
                // ...
            }
            else
            {
                // ...
            }
        }
        return View();
    }
