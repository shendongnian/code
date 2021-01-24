    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult UploadImage(HttpPostedFileBase imageUpload)
     {
               string path = Path.Combine(this.GetBasePath + "/img/tmp/", Path.GetFileName(imageFile.FileName));
               imageFile.SaveAs(path);
               return null;
      }
