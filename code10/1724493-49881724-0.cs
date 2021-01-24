    [TestMethod]
    public void Login_IsValidUser_ReturnsTrue()
    {
        var deserializedObject = new EmployeeData() {
            //...
        };
    
        m_JavascriptSerializerWrapper
            .Setup(_ => _.Deserialize(It.IsAny<string>())) //<-- note use of argument matcher
            .Returns(deserializedObject);
    
        //...
    }
