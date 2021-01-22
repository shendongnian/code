    public ActionResult ProfileImage(string userName)
    {
       var imageByteArray = // get image bytes from DB corresponding to userName
       string contentType = // get image content type from DB for example "image/jpg"
       string fileName = // get image file name from DB
       return File(imageByteArray, contentType, fileName);
    }
