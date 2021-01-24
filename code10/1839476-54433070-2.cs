    Point lbMouseDownPosition = Point.Empty;
    List<int> lbSelectedIndexes = new List<int>();
    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        var lb = sender as ListBox;
        lbMouseDownPosition = e.Location;
        lbSelectedIndexes = new List<int>();
        int idx = lb.IndexFromPoint(e.Location);
        if (ModifierKeys == Keys.Shift && idx != lb.SelectedIndex) {
            lbSelectedIndexes.AddRange(Enumerable.Range(
                Math.Min(idx, lb.SelectedIndex),
                Math.Abs((idx - lb.SelectedIndex)) + 1).ToArray());
        }
    }
    private void listBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && 
            ((Math.Abs(e.X - lbMouseDownPosition.X) > SystemInformation.DragSize.Width) || 
             (Math.Abs(e.Y - lbMouseDownPosition.Y) > SystemInformation.DragSize.Height)))
        {
            var lb = sender as ListBox;
            DataObject obj = new DataObject();
            if (lbSelectedIndexes.Count == 0) {
                lbSelectedIndexes = lb.SelectedIndices.OfType<int>().ToList();
            }
            List<object> selection = lb.Items.OfType<object>().Where((item, idx) =>
                lbSelectedIndexes.IndexOf(idx) >= 0).ToList();
            obj.SetData(typeof(IList<ListItemsTest>), selection);
            lb.DoDragDrop(obj, DragDropEffects.Copy);
        }
    }
