    public IActionResult GetMyClassData(int ID, int isdownload)
    {
       myclassdata = myclassdataBL.GetMyClassData(ID);
       if (isDownload == 1)
           return File(...);
       return Ok(myclassdata);
    }
