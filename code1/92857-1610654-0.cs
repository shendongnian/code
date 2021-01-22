    [Test]
    public void CloneRowCellsTest()
    {
      UltraGridRow objSource = new UltraGridRow();
      objSource.Cells.Add(new UltraGridCell("Original value for cell 0"));
      objSource.Cells.Add(new UltraGridCell("Original value for cell 1"));
      UltraGridRow objDestination = new UltraGridRow();
      objDestination.CopyFrom(objSource);
      objDestination.Cells[1].Value = "New value for cell 1";
      Assert.AreEqual(objSource.Cells.Count, objDestination.Cells.Count);
      Assert.AreEqual("Original value for cell 0", objDestination.Cells[0].Value);  //Ensure that the value was copied
      Assert.AreEqual("New value for cell 1", objDestination.Cells[1].Value);       //Ensure that the new value was set
      Assert.AreEqual("Original value for cell 1", objSource.Cells[1].Value);       //Ensure that the original was unchanged
    }
