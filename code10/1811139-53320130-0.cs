    public ActionResult ViewProfile()
        { 
    if(Session["UserID"]!=null)
    {
    var userDetails = db.tblUsers.Where(x => x.uid==Session["UserID"].tosting()).ToList();
    ///here your code
            return View( userDetails );
        }
