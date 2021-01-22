    public static TreeViewItem FindTviFromObjectRecursive(ItemsControl ic, object o) {
      //Search for the object model in first level children (recursively)
      TreeViewItem tvi = ic.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;
      if (tvi != null) return tvi;
      //Loop through user object models
      foreach (object i in ic.Items) {
        //Get the TreeViewItem associated with the iterated object model
        TreeViewItem tvi2 = ic.ItemContainerGenerator.ContainerFromItem(i) as TreeViewItem;
        tvi = FindTviFromObjectRecursive(tvi2, o);
        if (tvi != null) return tvi;
      }
      return null;
    }
