    [TestMethod]
    public void VerifyArrays()
    {
        int[] actualArray = { 1, 3, 7 };
        CollectionAssert.AreEqual(new int[] { 1, 3, 7 }, actualArray);
    }
