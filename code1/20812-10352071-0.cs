    public static void AreEqualByJson(object expected, object actual)
    {
        System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var expectedJson = oSerializer.Serialize(expected);
        var actualJson = oSerializer.Serialize(actual);
        Assert.AreEqual(expectedJson, actualJson);
    }
