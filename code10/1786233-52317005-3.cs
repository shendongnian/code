    public ActionResult Index(){
    return View();}public ActionResult LoadData()
        {
             List<CarModel> objCar = new List<CarModel>()
    {
        new CarModel {ProductBrand="BMW",ProductName="X4", ProductColor="White", Price=57000 },
        new CarModel {ProductBrand="Mercedes",ProductName="AMG", ProductColor="Black", Price=61000 },
        new CarModel {ProductBrand="BMW",ProductName="X6", ProductColor="Black", Price=32000 },
        new CarModel {ProductBrand="BMW",ProductName="X5", ProductColor="White", Price=28000 },
        new CarModel {ProductBrand="BMW",ProductName="X3", ProductColor="White", Price=30000 }
    };
    CarModelDetail ObjCarDetails = new CarModelDetail();
    ObjCarDetails.OrderDetails = objCar;
            return Json(new { data = objCar }, JsonRequestBehavior.AllowGet);
        }
