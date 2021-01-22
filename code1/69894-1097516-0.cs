    public static void TestCustomException<T>() where T : Exception
    {
        var t = typeof(T);
        //Custom exceptions should have the following 3 constructors
        var e1 = (T)Activator.CreateInstance(t, null);
        
        const string message = "message";
        var e2 = (T)Activator.CreateInstance(t, message);
        Assert.AreEqual(message, e2.Message);
        var innerEx = new Exception("inner Exception");
        var e3 = (T)Activator.CreateInstance(t, message, innerEx);
        Assert.AreEqual(message, e3.Message);
        Assert.AreEqual(innerEx, e3.InnerException);
        //They should also be serializable
        var stream = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, e3);
        stream.Flush();
        stream.Position = 0;
        var e4 = (T)formatter.Deserialize(stream);
        Assert.AreEqual(message, e4.Message);
        Assert.AreEqual(innerEx.ToString(), e4.InnerException.ToString());
    }
