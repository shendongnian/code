    void listBox1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left && listBox1.SelectedItems.Count > 0) {
        int mouseIndex = listBox1.IndexFromPoint(e.Location);
        if (mouseIndex > -1) {
          ListBox.SelectedObjectCollection x = new ListBox.SelectedObjectCollection(listBox1);
          if (Control.ModifierKeys == Keys.Shift) {
            int i1 = Math.Min(listBox1.SelectedIndex, mouseIndex);
            int i2 = Math.Max(listBox1.SelectedIndex, mouseIndex);
            for (int i = i1; i <= i2; ++i) {
              x.Add(listBox1.Items[i]);
            }
          } else {
            x = listBox1.SelectedItems;
          }
          var dropResult = DoDragDrop(x, DragDropEffects.Move);
        }
      }
    }
