                var myFile :: your file
        if (System.IO.File.Exists (myFile.Path)) {// to know if the file is Exist or not
         //Process File Here ...
        } else {
          return Json ("NotFound");
        }
        string contentType = "application/xml"; 
        HttpContext.Response.ContentType = contentType;
        var result = new FileContentResult (System.IO.File.ReadAllBytes (myFile.Path), contentType) {
          FileDownloadName = $"{myFile.Title }" // + myFile.Extension
        };
       // System.IO.File.Delete (myFile.Path);  //if you want to delete the file after download
        return result;
