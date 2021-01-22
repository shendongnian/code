    public ActionResult register(FormCollection collection, HttpPostedFileBase FileUpload1){
    RegistrationIMG regimg = new RegistrationIMG();
    string ext = Path.GetExtension(FileUpload1.FileName);
    string path = Server.MapPath("~/image/");
    FileUpload1.SaveAs(path + reg.email + ext);
    regimg.Image = @Url.Content("~/image/" + reg.email + ext);
    db.SaveChanges();}
