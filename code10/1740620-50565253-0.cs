        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.SESDataViewModel sESData)
        {
            if (ModelState.IsValid)
            {
                db.SESData.Add(sESData.Main);
                foreach (var reg in sESData.Regs){
                    db.SESRegulationList.Add(reg);
                    db.SaveChanges();    
                 }           
                return RedirectToAction("Report", new { id = sESData.Main.id});
            }
            return View(sESData);
        }
