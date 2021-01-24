    public ActionResult EditFruits(IEnumerable<Fruit> model)
    {
        if(this.Request.Form.AllKeys.Contains("Delete"))
             DeleteSelectedFruits(model);
        else if(this.Request.Form.AllKeys.Contains("Update"))
             UpdateSelectedFruits(model);
        return Wherever you want to go.
    }
