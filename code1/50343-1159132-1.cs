    public class myViewDataObj
        {
            public SelectList PageOptionsDropDown { get; set; }
        }
    public ActionResult About()
            {
                myViewDataObj myViewData = new myViewDataObj();
                myViewData.PageOptionsDropDown =
                      new SelectList(new[] { "10", "15", "25", "50", "100", "1000" }, "15");
    
                ViewData["myList"] = myViewData.PageOptionsDropDown;
                return View();
            }
