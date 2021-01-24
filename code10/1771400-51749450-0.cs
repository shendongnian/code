    protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        if (this.SelectionLength > 1)
        {
            this.SelectionLength = 0;
            e.Handled = false;
        }
        if (e.Key == Key.Insert || e.Key == Key.Delete || e.Key == Key.Back || (e.Key == Key.Space && _ignoreSpace))
        {
            StringBuilder sb = new StringBuilder(this.Text);
            if (sb[CaretIndex - 1] != '-')
            {
                sb[CaretIndex - 1] = '_';
            }
            this.Text = sb.ToString();
            e.Handled = true;
        }
        base.OnPreviewKeyDown(e);
    }
