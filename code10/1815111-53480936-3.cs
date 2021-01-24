    public ActionResult SomeAction()
    {
        var org = GetOrg(); //your org
        var orgNames = GetOrgNames(); //your orgNames
        // . . .
        ViewBag.DropDownListValue = new SelectList(org.Select(s => new SampleViewModel 
        {  
            DropDownListValue = $"{s} - {orgNames[s]}"
        }, "DropDownListValue", "DropDownListValue");
        return View(new SampleViewModel())
    }
