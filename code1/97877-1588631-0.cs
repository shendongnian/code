    private void listBox_DragOver(object sender, 
      DragEventArgs e)
    {
      indexOfItem = 
        listBox.IndexFromPoint(listBox.PointToClient(new Point(e.X, e.Y)));
      if (indexOfItem != ListBox.NoMatches)
      {
         //do whatever - select it, etc
      }
    }
