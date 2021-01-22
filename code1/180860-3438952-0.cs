    private void MouseDown_handler(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox) sender;
            if (e.Clicks != 1)
            {
                DoubleClick_handler(listBox1.SelectedItem);
                return;
            }
            var pt = new Point(e.X, e.Y);
            int index = listBox.IndexFromPoint(pt);
            // Starts a drag-and-drop operation with that item.
            if (index >= 0)
            {
                var item = (listBox.Items[index] as MyObject).CommaDelimitedString();
                listBox.DoDragDrop(item, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
