    XNamespace rsNamespace = XNamespace.Get("urn:schemas-microsoft-com:rowset");
    XNamespace zNamespace = XNamespace.Get("#RowsetSchema");
    var rowQuery = from Mail in whiteMails.Elements("xml")
                                          .Elements(rsNamespace + "data")
                                          .Elements(zNamespace + "row")
                   select Mail;
