    using System.Runtime.Serialization.Json;
    [TestMethod]
    public void DataObjectSimpleParseTest()
    {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataObject));
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(JsonData));
            DataObject dataObject = serializer.ReadObject(ms) as DataObject;
            Assert.IsNotNull(dataObject);
            Assert.AreEqual("low", dataObject.DetailLevel);
            Assert.AreEqual(1234, dataObject.UserId);
    }
