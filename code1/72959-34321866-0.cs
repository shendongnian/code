        private DBEntities db = new DBEntities();//dbcontext
        //Solution 1: turn off ProxyCreation for the DBContext and restore it in the end 
        public ActionResult Index()
        {
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                //set ProxyCreation to false
                db.Configuration.ProxyCreationEnabled = false;
                var data = db.Products.ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                //restore ProxyCreation to its original state
                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }
        //Solution 2: Using JsonConvert by Setting ReferenceLoopHandling to ignore on the serializer settings. 
        //using using Newtonsoft.Json;
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
        //Solution 3: return a new dynamic object which includes only the needed properties.
        public ActionResult Index()
        {
            try
            {
                var data = db.Products.Select(p => new
                                                    {
                                                        Product_ID = p.Product_ID,
                                                        Product_Name = p.Product_Name,
                                                        Product_Price = p.Product_Price
                                                    }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }
