    [TestMethod]
    public void TestNQueens()
    {
      Assert.AreEqual(1, new NQueensSolver(1).FindAllFormations().Count);
      Assert.AreEqual(0, new NQueensSolver(2).FindAllFormations().Count);
      Assert.AreEqual(0, new NQueensSolver(3).FindAllFormations().Count);
      Assert.AreEqual(2, new NQueensSolver(4).FindAllFormations().Count);
      Assert.AreEqual(10, new NQueensSolver(5).FindAllFormations().Count);
      Assert.AreEqual(4, new NQueensSolver(6).FindAllFormations().Count);
      Assert.AreEqual(40, new NQueensSolver(7).FindAllFormations().Count);
      Assert.AreEqual(92, new NQueensSolver(8).FindAllFormations().Count);
      Assert.AreEqual(352, new NQueensSolver(9).FindAllFormations().Count);
      Assert.AreEqual(724, new NQueensSolver(10).FindAllFormations().Count);
    }
