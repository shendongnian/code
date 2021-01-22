        private DBEntities db = new DBEntities();//dbcontext
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
