    public ActionResult SomeActionThatReturnsJson()
    {
        var someObjectThatContainsManyProperties = GetObjectFromSomeWhere();
        return Json(new {
            Name = someObjectThatContainsManyProperties.Name,
            Phone = someObjectThatContainsManyProperties.Phone,
        });
    }
