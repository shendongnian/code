        private DBEntities db = new DBEntities();//dbcontext
        public class ProductModel
        {
            public int Product_ID { get; set;}
            
            public string Product_Name { get; set;}
            
            public double Product_Price { get; set;}
        }
        public ActionResult Index()
        {
            try
            {
                var data = db.Products.Select(p => new ProductModel
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
