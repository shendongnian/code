    [HttpPost]
    public ActionResult Edit(EditUserVm model)
    {
       var db = new BazaProjekatEntities4()
       var user = db.Korisniks.FirstOrDefault(x => x.KorisnikID == model.Id);
       user.Admin = model.Admin.
       user.Gost = model.Gost;
       user.PravoUnosa = model.PravoUnosa;
    
       db.Entry(k).State = EntityState.Modified;
       db.SaveChanges();
    
       return RedirectToAction("Index");
    } 
