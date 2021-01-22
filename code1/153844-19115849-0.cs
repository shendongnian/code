    [HttpPost]
    public JsonResult GetDestinations(string countryId)
    {
        List<Destination> destinations = new List<Destination>();
        string destinationsXml = SharedMethods.GetDestinations();
        XDocument xmlDoc = XDocument.Parse(destinationsXml);
        var d = from country in xmlDoc.Descendants("Country")
                from destinationsx in country.Elements("Destinations")
                from destination in destinationsx.Elements("Destination")
                where (string)country.Attribute("ID") == countryId
                select new Destination
                {
                    Name = destination.Attribute("Name").Value,
                    ID = destination.Attribute("ID").Value,
                };
        destinations = d.ToList();
        return Json(new JsonResult { Data = destinations}, JsonRequestBehavior.AllowGet);
    }
