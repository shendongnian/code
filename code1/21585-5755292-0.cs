        private void MessageTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {
                foreach (string filePath in ((DataObject)e.Data).GetFileDropList())
                {
                    // Processing here     
                }
            }
        }
        private void MessageTextBox_PreviewDragEnter(object sender, DragEventArgs e)
        {
            var dropPossible = e.Data != null && ((DataObject)e.Data).ContainsFileDropList();
            if (dropPossible)
            {
                e.Effects = DragDropEffects.Copy;
            }
        }
        private void MessageTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
