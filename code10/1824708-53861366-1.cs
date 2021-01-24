    public ActionResult Edit(int id)
    {
      using (var dbModel = new BazaProjekatEntities4())
      {
         var user = dbModel.Korisniks.FirstOrDefault(x => x.KorisnikID == id);
         // to do: If user is NULL, return a "Not found" view to user ?
         var vm = new EditUserVm { Id = id };
         vm.UserName = user.UserName;
         vm.Admin = user.Admin;
         vm.Gost = user.Gost;
         vm.PravoUnosa = user.PravoUnosa;
         return View(vm);
      }
    }
