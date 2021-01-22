    public ActionResult SomeActionThatReturnsJson()
    {
        var users = from element in GetObjectsFromSomeWhere()
                    select new {
                        Name = element.Name,
                        Phone = element.Phone,
                    };
        return Json(users.ToArray());
    }
