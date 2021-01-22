    Type listOfT = typeof(List<>);
    Type listOfString = typeof(List<string>);
    Type listOfInt32 = typeof(List<int>);
    
    Assert.IsTrue(listOfString.IsGenericType);
    Assert.AreEqual(typeof(string), listOfString.GetGenericTypeParameters()[0]);
    Assert.AreEqual(typeof(List<>), listOfString.GetGenericTypeDefinition());
