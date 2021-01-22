    //Below works precisely well, Use it.
    private void CompareJson()
    {
    object expected = new object();
    object actual = new object();
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    var expectedResponse = serializer.Serialize(expected);
    var actualResponse = serializer.Serialize(actual);
    Assert.AreEqual(expectedResponse, actualResponse);
    }
