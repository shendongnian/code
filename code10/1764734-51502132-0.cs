    public ActionResult GetPais()
    {    
        using (MyEntities ctx = new MyEntities())
        {
            var model = new MySite.Models.CountrisList();
            model.Countries = ctx.Countries.ToList();
            return PartialView("_optionsPais", model);
        }
    }
