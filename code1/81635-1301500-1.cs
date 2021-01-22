    private void currentTagNotContactsList_Scroll(object sender, ScrollEventArgs e) {
        ScrollBar sb = e.OriginalSource as ScrollBar;
        if (sb.Orientation == Orientation.Horizontal)
            return;
        if (sb.Value == sb.Maximum) {
            Debug.Print("At the bottom of the list!");
        }
    }
