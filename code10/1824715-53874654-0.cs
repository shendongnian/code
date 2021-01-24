    [HttpPost]
    public ActionResult Edit(EditUserVm model)
    {
       var db = new BazaProjekatEntities4();
       var user = db.Korisniks.FirstOrDefault(x => x.KorisnikID == model.Id);
       // to do : Do a null check on user to be safe :)
    
       // Map the property values from view model to entity object
       user.Admin = model.Admin;
       user.PotvrdiLozinku = user.Lozinka;  // this line was missing
       user.Gost = model.Gost;
       user.PravoUnosa = model.PravoUnosa;
    
       db.Entry(k).State = EntityState.Modified;
       db.SaveChanges();
    
       return RedirectToAction("Index");
    } 
