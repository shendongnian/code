    var dictionary = new Dictionary<string, object>();
    
    var applicationSettingsBaseMock = new Mock<SettingsBase>();
    applicationSettingsBaseMock
    	.Setup(sb => sb[It.IsAny<string>()])
    	.Returns((string key) => dictionary[key]);
    applicationSettingsBaseMock
    	.SetupSet(sb => sb["Expected Key"] = It.IsAny<object>())
    	.Callback((string key, object vaue) => dictionary[key] = vaue);
