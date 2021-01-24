    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult NuevoProveedor(SubirArchivoModelo model)
    {
        if (ModelState.IsValid)
        {
            if(Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentLength > 0) 
                {
                    var fileName = Path.GetFileName(file.FileName);
                    model.FileLocation = Path.Combine(
                        Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(model.FileLocation);
                }
                //db.TableEntity.Add(model);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
        }
    
        return View("UsuarioNuevo");
    }
