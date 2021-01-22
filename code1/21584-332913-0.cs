    private void btnFindType_Drop(object sender, DragEventArgs e)
    {
      if (e.Data is System.Windows.DataObject &&
        ((System.Windows.DataObject)e.Data).ContainsFileDropList())
      {
        foreach (string filePath in ((System.Windows.DataObject)e.Data).GetFileDropList())
        {
          // Processing here
        }
      }            
    }
