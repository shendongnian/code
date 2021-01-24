     public class CityAreaBindingModel
        {
            public int CityID { get; set; }
            public int AreaID { get; set; }
        }
    
        public class City
        {
            public int ID { get; set; }
            public string Title { get; set; }
        }
    
        public class Area
        {
            public int ID { get; set; }
            public string Title { get; set; }
        }
    
        public class SaleController : Controller
        {
            public ActionResult GetSaleCentersByLocation()
            {
                ViewData["Cities"] = new List<City>
                {
                    new City {ID = 1, Title = "Hanoi"},
                    new City {ID = 2, Title = "SaiGon"}
                };
    
                ViewData["Areas"] = new List<Area>
                {
                    new Area {ID = 1, Title = "Area1"},
                    new Area {ID = 2, Title = "Area2"}
                };
                return View();
            }
    
    
            [HttpPost]
            public JsonResult GetSaleCentersByLocation(CityAreaBindingModel model)
            {
                GeneralStore gs = new GeneralStore();
                var saleCentersByCity = gs.GetSaleCentersByCity(model.CityID);
                var result = new JsonResult();
                result.Data = saleCentersByCity;
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
    
                return result;
            }
        }
    
        public class GeneralStore
        {
            public object GetSaleCentersByCity(int modelCityId)
            {
                return new { Id = 1, Name = "Test"};
            }
        }
