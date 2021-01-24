    [HttpPost]
    public JsonResult CityLookup(string postcode)
    {
	    var client = new PostcodesIOClient();
        var result = client.Lookup(postcode);
        var jst = new AddressLookupViewModel();
        jst.City = result.AdminDistrict;
	    jst.County = result.AdminCounty;
	    jst.PostCode = postcode;
	    return Json(jst);
    }
