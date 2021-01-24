    [HttpPost]
    public JsonResult Index(FilterRule obj)
    {
        var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var personBuilder = new PersonBuilder(); // add constructor initialization first
        var people = personBuilder.GetPeople().BuildQuery(obj).ToList();
    
        return Json(people);
    }
