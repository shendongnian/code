    [Test]
    public void Test()
    {
       var chars = new [] {'a', 'b', '\0', 'c', '\0', '\0'};
       File.WriteAllBytes("test.dat", Encoding.ASCII.GetBytes(chars));
       var content = File.ReadAllText("test.dat");
       Assert.AreEqual(6, content.Length); // includes the null bytes at the end
       content = content.Trim('\0');
       Assert.AreEqual(4, content.Length); // no more null bytes at the end
                                           // but still has the one in the middle
    }
