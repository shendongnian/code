    public ActionResult Download() 
    {
        byte[] contents = GetFileContentsFromDatabase();
        return File(contents, "image/jpeg")
    }
