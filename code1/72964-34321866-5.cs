        //using using Newtonsoft.Json;
        private DBEntities db = new DBEntities();//dbcontext
        public ActionResult Index()
        {
            try
            {
                var data = db.Products.ToList();
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }
