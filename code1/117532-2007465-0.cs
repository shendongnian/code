    WebGetAttribute attrib = (WebGetAttribute)Attribute.GetCustomAttribute(
        typeof(IMyServer).GetMethod("ServerInfo"),
        typeof(WebGetAttribute));
    Assert.IsNotNull(attrib);
    Assert.AreEqual("info", attrib.UriTemplate);
