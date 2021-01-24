    public IActionResult GetMyClassData(int ID, int isdownload)
    {
       myclassdata = myclassdataBL.GetMyClassData(ID);
       if (isDownload)
           return File(...);
       return Ok(myclassdata);
    }
