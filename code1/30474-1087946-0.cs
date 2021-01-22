    private void MyDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
      if (e.EditAction == DataGridEditAction.Cancel)
      {
        e.Cancel = false;
        return;
      }
    
      if (e.EditAction == DataGridEditAction.Commit)
      {
        DataGridRow dgr = e.Row;
        XmlElement xe = myXmlDataProvider.Document.CreateElement("NewRowElement");
        foreach(DataGridCell cell in dgr.Cells)
        {
          xe.SetAttribute(cell.Name, cell.Value);
        }
        dataProvider.Document.DocumentElement.AppendChild(xe);
        e.Cancel = true;
      }
    }
