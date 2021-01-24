    var home = new Home();
    home.Id = 2;
    home.propertyName = "text1";
    var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
    jsonResolver.RenameProperty(typeof(Home), "propertyName", "administration");
    var serializerSettings = new JsonSerializerSettings();
    serializerSettings.ContractResolver = jsonResolver;
    var json = JsonConvert.SerializeObject(home, serializerSettings);
