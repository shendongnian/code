    [TestMethod]
    public void MockRowsTest()
    {
        var row1 = MockUtils.MockCells("test_row_1", "test_row_1");
        var row2 = MockUtils.MockCells("test_row_2", "test_row_2");
        var range = MockUtils.MockRows(row1, row2);
        Assert.IsNotNull(range);
        Assert.AreEqual(2, range.Count);
        Assert.IsNotNull(range.Rows);
        Assert.AreEqual(2, range.Rows.Count);
        Range x = range.Rows[1];
        Range y = range.Rows[2];
        var xCell = x.Cells[1];
        var yCell = y.Cells[1];
        Assert.AreSame(row1, x); 
        Assert.AreSame(row2, y);
        Assert.AreEqual("test_row_1", xCell.Value2);
        Assert.AreEqual("test_row_2", yCell.Value2);
    }
