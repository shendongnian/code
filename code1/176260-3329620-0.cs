    [TestMethod]
    public void Set_The_Origin_As_Violet_And_The_Query_Confirms_It() {
        // Arrange
        Board board = new Board(10, 10);
        // Act
        board.SetColorAt(0, 0, expected);
        // Assert
        Color expected = Color.Violet;
        Assert.AreEqual(expected, board.GetColorAt(0, 0));
    }
