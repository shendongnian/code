    [HttpGet]
        public ActionResult Get()
        {
            DBEntities db = new DBEntities();
            var result = db.GetMenuMaster();
            return new JsonResult
            {
                Data = result,
                ContentEncoding = Encoding.UTF8,
                ContentType = "application/json",
                MaxJsonLength  = int.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
