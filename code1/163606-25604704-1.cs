        private void resultsListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != resultsListView) return;
            if (e.Control && e.KeyCode == Keys.C)
                CopySelectedValuesToClipboard();
        }
        private void CopySelectedValuesToClipboard()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in resultsListView.SelectedItems)
                builder.AppendLine(item.SubItems[1].Text);
            Clipboard.SetText(builder.ToString());
        }
