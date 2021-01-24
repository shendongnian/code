    HttpGet("api/values/{id:int}/{testOne:type}/{testTwo:type}")]
    public ActionResult<string> Get(int id, type testOne, type testTwo)
    {
        TestRequest model = new TestRequestModel();
        request.id = id;
        request.TypeOne = typeOne;
        .....
    }
