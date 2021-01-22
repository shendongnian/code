    bool CanDrop(DragDropEventArgs args) {
      Point point = tree.PointToClient(new Point(e.X, e.Y));
      TreeNode target = tree.GetNodeAt(point);
      TreeNodeController targetController = target.Tag as TreeNodeController;
     
      DataInfoObject info = args.GetData(typeof(DataInfoObject)) as DataInfoObject;
      TreeNodeController sourceController = args.GetData(typeof(TreeNodeController)) as TreeNodeController;
    
      if (info != null) return targetController.CanDrop(info, e.Effect);
      if (sourceController != null) return targetController.CanDrop(sourceController, e.Effect);
      return false;
    }
