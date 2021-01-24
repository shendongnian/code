    var wPos = this.myListView.PointToClient(new Point(e.X, e.Y));
    var targetItem = myListView.GetItemAt(wPos.X, wPos.Y);
    if (targetItem != null)
    {
          var targetNodeInfo = targetItem.Tag as WindowsExplorerModel;
          if (targetNodeInfo != null)               //if dropping on a target item
          {
               if (targetNodeInfo.isFile)               
                    e.Effect = DragDropEffects.None;//if IsFile                    
               else
               {
                    foreach (ListViewItem listItem in myListView.SelectedItems)
                            listItem.Selected = false;
                    targetItem.Selected = true;
                    e.Effect = DragDropEffects.Copy;
                }
                return;
          }                                
    }
