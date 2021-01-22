    [TestMethod]
    public void TestMethod1()
    {
        int[] intArray = { 4, 8, 15, 16, 23, 42, 108, 342, 815, 1087, 6717 };
    
        byte[] inputBytes = new byte[intArray.GetLength(0) * 4];
    
        Buffer.BlockCopy(intArray, 0, inputBytes, 0, intArray.GetLength(0) * 4);
    
        int[] outputInts = new int[intArray.GetLength(0)];
    
        Buffer.BlockCopy(inputBytes, 0, outputInts, 0, intArray.GetLength(0) * 4);
    
        Assert.IsTrue(Enumerable.SequenceEqual(intArray, outputInts));
    
    }
