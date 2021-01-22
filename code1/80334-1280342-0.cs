    [Test]
    public void SelectCheckedChanged_SetsModeToColumnHeaderSelect () {
        //Arrange
        //Mock the form to return a stubbed grid
        Mock<IQueryForm> form = new Mock<IQueryForm>();
        DataGridView grid = new DataGridView();
        grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
        form.SetupGet(f => f.QueryResults).Returns(grid);
        QueryFormPresenter presenter = new QueryFormPresenter(form.Object);
        //Act
        presenter.SelectCheckedChanged();
        //Assert
        form.VerifyGet(f => f.QueryResults);
        Assert.AreEqual(DataGridViewSelectionMode.ColumnHeaderSelect, 
                        grid.SelectionMode);
    }
