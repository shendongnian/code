        private void trashCan_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(ListViewItem))) {
                e.Effect = DragDropEffects.Move;
            }
            // others...
        }
        private void trashCan_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(ListViewItem))) {
                var item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
                item.ListView.Items.Remove(item);
            }
            // others...
        }
