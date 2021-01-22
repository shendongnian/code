      private void MoveSelection(int level)
      {
         var newIndex = this.SelectedIndex + level;
         if (newIndex >= 0 && newIndex < this.Items.Count)
         {
            this.SelectedItem = this.Items[newIndex];
            this.UpdateLayout();
            var selectedItem = (ListViewItem)this.ItemContainerGenerator.ContainerFromIndex(newIndex);
            selectedItem.Focus();
         }
      }
