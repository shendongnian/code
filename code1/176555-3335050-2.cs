        private void myList_ItemDrag(object sender, ItemDragEventArgs e)
            {
                DoDragDrop(e.Item, DragDropEffects.Link);
            }
    
            private void myList_DragEnter(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Link;
            }
    
            private void myList_DragDrop(object sender, DragEventArgs e)
            {
                // do whatever you need to reorder the list.
            }
