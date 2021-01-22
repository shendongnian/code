    public ActionResult TestRouting(string query)
    {
        if (query == "NewYork")
        {
            var model = ...somehow get "New York" model
            return View("Index", model );
        }
        else if (query == "name-of-business")
        {
            var model = ...get "nameofbusiness" model
            return View("Details", model );
        }
        else
        {
            return View("TestTabs");
        }
    }
