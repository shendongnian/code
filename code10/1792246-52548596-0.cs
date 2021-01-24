    [HttpGet]
    public ActionResult Open(int id)
    {
        string path = "";
        path = db.tblLetters.Where(t => t.ID == id).SingleOrDefault().LetterImg;
        string fileName = path.Substring(path.LastIndexOf(@"\")+1);
        string p = Server.MapPath("~/Files/LettersImgs/" + fileName);
        return File(p, "application/octet-stream", fileName);
    }
