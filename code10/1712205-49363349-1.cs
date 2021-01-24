    [System.Web.Http.HttpPost]
    public System.Web.Http.IHttpActionResult Post([System.Web.Http.FromBody] CallBackFormModel CallBackFormModel)
    {
        // your previous code goes here
        return Json(new { result = "ok" }, JsonRequestBehavior.AllowGet);
    }
