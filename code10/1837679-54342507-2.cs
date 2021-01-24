    [HttpPost]
    public ActionResult CreateTeam(Team model, HttpPostedFileBase upload)
    {
         if (ModelState.IsValid)
         {
              if (upload != null)
              {
                  // Get the file
                  string fileName = System.IO.Path.GetFileName(upload.FileName);
                  var fileUploadPath = Path.Combine(Server.MapPath("~/Images/NBAlogoImg/"),fileName);
                  upload.SaveAs(fileUploadPath);
              }
             teamRepository.CreatTeam(model);
    
             return RedirectToAction("Index", "Player");
        }
    
        return View(model);
    }
