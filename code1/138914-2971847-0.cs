    using Newtonsoft.Json;
    public ActionResult Index() {
      JsonSerializerSettings jsSettings = new JsonSerializerSettings();
      jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      var nodes = SiteMap.Provider.RootNode;
      return Content(JsonConvert.SerializeObject(
        new { Data = nodes }, Formatting.None, jsSettings));
    }
