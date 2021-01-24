    [HttpPost]
    public ActionResult Edit(NewForm model)
    {
        Response.Write(model.FirstField);
        Response.Write(model.Field);
        Response.Write(model.Check);
    }
