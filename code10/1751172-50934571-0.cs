    public ActionResult GetModalPartialView(long UserId){
     //map your db result to a view model.
     var model = db_RIRO.sp_GetUserDetails(id).FirstOrDefault();
     //return your view
     return view("~/Views/Shared/_Modal.cshtml",model);
    }
