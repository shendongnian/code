     newParent = currentParent.ItemContainerGenerator.ContainerFromIndex(index) as TreeViewItem;
     if (newParent == null)
     {
          currentParent.UpdateLayout();
          virtualizingPanel.BringIndexIntoViewPublic(index);
          newParent = currentParent.ItemContainerGenerator.ContainerFromIndex(index) as TreeViewItem;
     }
