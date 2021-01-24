    [HttpPost]
    public ActionResult KonutGuncelle(Konut konut, KonutOzellik ko)
    {
        KonutOzellik willBeUpdatedko = ctx.KonutOzellik.SingleOrDefault(x => x.KonutOzellikID == konut.KonutOzellikID);
        willBeUpdatedko.InjectFrom(ko); // New code with ValueInjecter
        Konut willBeUpdatedkonut = ctx.Konut.SingleOrDefault(x => x.id == konut.id);
        willBeUpdatedko.InjectFrom(konut); // New code with ValueInjecter
        ctx.SaveChanges(); // Must save changes?
        return RedirectToAction("KonutGuncelle", new { konut.id });
    }
