    [HttpPost]         
    public ActionResult MyViewModel1Validator(MyViewModel1 model)         
    {         
        return ValidateHelper(model);         
    }         
             
    [HttpPost]         
    public ActionResult MyViewModel2Validator(MyViewModel2 model)         
    {         
        return ValidateHelper(model);         
    }
    
    private ActionResult ValidateHelper(IMyViewModel model) {
        var validator = model.Validate();         
             
        var output = from Error e in validator.Errors         
                     select new { Field = e.FieldName, Message = e.Message };         
             
        return Json(output);
    }
