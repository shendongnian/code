    [Test]
    public void Test()
    {
       var chars = new [] {'a', 'b', 'c', '\0', '\0'};
       File.WriteAllBytes("test.dat", Encoding.ASCII.GetBytes(chars));
       var content = File.ReadAllText("test.dat");
       Assert.AreEqual(5, content.Length); // includes the null bytes
       content = content.Trim('\0');
       Assert.AreEqual(3, content.Length); // no more null bytes
    }
