    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Edit(string id, FormCollection form)
    {
    //assuming you have some kind of PK
    var plot = Plot.SingleOrDefault(p => p.ID == id);    
    UpdateModel(plot, form.ToValueProvider());
    var validator = new PlotValidator();
        try
        {
            var results = validator.Validate(plot);
            if (!results.IsValid)
            {
                ...
            }
        }
    }
