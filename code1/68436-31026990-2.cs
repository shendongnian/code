      private void MoveSelection(int level)
      {
         var newIndex = this.SelectedIndex + level;
         if (newIndex >= 0 && newIndex < this.Items.Count)
         {
            this.SelectedItem = this.Items[newIndex];
            this.UpdateLayout();
            ((ListViewItem)this.ItemContainerGenerator.ContainerFromIndex(newIndex)).Focus();
         }
      }
