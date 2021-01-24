    data.append("key", "test");
    data.append("value", "test");
    public ActionResult Upload(string key, string value)
    {
        //key = test, value = test
        var files = Request.Files; //HttpFileCollectionBase
    }
