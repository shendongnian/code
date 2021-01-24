    ...
    string core_URL = BaseURL_Core+URL_instance;
    var response = await client_Core.GetAsync(core_URL);
    string xml = await response.Content.ReadAsStringAsync();
    System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Parse(xml);
    responsedata = doc.Root.Value;
    ...
