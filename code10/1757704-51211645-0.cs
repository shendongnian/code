    if (ModelState.IsValid)
    {
       //your post code to db
    }
    else
    {
       var modelState = ModelState.ToDictionary
       (
           kvp => kvp.Key,
           kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
       );
      return Json(new { modelState = modelState }, JsonRequestBehavior.AllowGet);
    }
