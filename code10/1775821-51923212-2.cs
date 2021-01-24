    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Details([Bind(Include = "AvisoId,Cliente,Data,Email,Telefone,Observacao,Enviado,Usuario")] Aviso aviso)
    {
        if (ModelState.IsValid)
        {
            db.Entry(aviso).State = EntityState.Modified;
            db.SaveChanges();
            TempData["ExternalUrl"] = "https://other-site-in-new-window.com";
            return RedirectToAction("Index");
        }
        return View(aviso);
    }
