    [HttpPost]
    public ActionResult SomeAction(SampleViewModel model)
    {
        var org = GetOrg(); //your org
        var orgNames = GetOrgNames(); //your orgNames
        
        //. . . Validation etc..
        
        ViewBag.DropDownListValue = new SelectList(org.Select(s => new SampleViewModel 
        {  
            DropDownListValue = $"{s} - {orgNames[s]}"
        }, "DropDownListValue", "DropDownListValue", model.DropDownListValue);
    
    
        var doSomething = model.DropDownListValue; //Your selected value from DropDownList
        return View(model)
    }
