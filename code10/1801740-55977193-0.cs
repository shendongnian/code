    var TheCar = DBContext.Cars.Find(1);
    var Settings = new Newtonsoft.Json.JsonSerializerSettings
    {
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    };
    var TheJSON = Newtonsoft.Json.JsonConvert.SerializeObject(TheCar, TheCar.GetType().BaseType, Settings);
