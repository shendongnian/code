    private void listBox_DragOver(object sender, 
      DragEventArgs e)
    {
      //for ListView
      var point = listView.PointToClient(new Point(e.X, e.Y));
      var item = listView.GetItemAt( point.X, point.Y);     
      if(item != null)
      {
         //do whatever - select it, etc
      }
 
      //or, for ListBox 
      var indexOfItem = 
        listBox.IndexFromPoint(listBox.PointToClient(new Point(e.X, e.Y)));
      if (indexOfItem != ListBox.NoMatches)
      {
         //do whatever - select it, etc
      }
    }
