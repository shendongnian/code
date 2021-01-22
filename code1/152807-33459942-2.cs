    public ActionResult GenerateImage(...)
    {
        ...
        return File(fileResult.Buffer, fileResult.ContentType, ".jpg");
    }
