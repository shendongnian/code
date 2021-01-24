        public ActionResult ViewProfile()
            { 
        if(Session["UserID"]!=null)
        {
    //check user uid datatype 
    //then store in variable
    int useesionid=COnvert.toint32(Session["UserID"].tosting())
    
        var userDetails = db.tblUsers.Where(x => x.uid==useesionid).ToList();
        ///here your code
                return View( userDetails );
            }
