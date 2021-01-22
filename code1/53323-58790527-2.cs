public ActionResult Create()
{
    //declaring name value collection object
    NameValueCollection collection = new NameValueCollection();
    //adding new value to the name value collection object
    collection.Add("Id1", "wwe323");
    collection.Add("Id2", "454w");
    collection.Add("Id3", "tyt5656");
    collection.Add("Id4", "343wdsd");
    //generating query string
    string url = GenerateQueryString(collection);
    return View();
}
private string GenerateQueryString(NameValueCollection collection)
{
    var querystring = (
        from key in collection.AllKeys
        from value in collection.GetValues(key)
        select string.Format("{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
    ).ToArray();
    return "?" + string.Join("&", querystring);
}
