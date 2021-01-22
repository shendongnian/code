    public ActionResult About()
            {
                myViewDataObj myViewData = new myViewDataObj();
                myViewData.PageOptionsDropDown =
                      new SelectList(new[] { "10", "15", "25", "50", "100", "1000" });
    
                ViewData["myListValues"] = myViewData.PageOptionsDropDown;
                ViewData["myList"] = "15";
                return View();
            }
