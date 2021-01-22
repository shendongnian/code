    private static void HandleListBoxKeyEvents(object sender, KeyEventArgs e)
    {
        var lb = sender as ListBox;
        // if copy
        if (e.Control && e.KeyCode == Keys.C)
        {
            // if shift is also down, copy everything!
            var itemstocopy = e.Shift ? lb.Items.Cast<object>() : lb.SelectedItems.Cast<object>();
            // build clipboard buffer
            var copy_buffer = new StringBuilder();
            foreach (object item in itemstocopy)
                copy_buffer.AppendLine(item?.ToString());
            if (copy_buffer.Length > 0)
                Clipboard.SetText(copy_buffer.ToString());
        }
        // if select all
        else if (e.Control && e.KeyCode == Keys.A)
        {
            lb.BeginUpdate();
            for (var i = 0; i < lb.Items.Count; i++)
                lb.SetSelected(i, true);
            lb.EndUpdate();
        }
    }
