    private void OnLoad()
    {
        textBox.PreviewKeyDown += OnPreviewKeyDown;
        textBox.KeyDown += OnKeyDown;
    }
    private void OnPreviewKeyDown( object sender, PreviewKeyDownEventArgs e)
    {
        if (e.Control)
        {
            e.IsInputKey = true;
        }
    }
    private void OnKeyDown( object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.C) {
            textBox.Copy();
        }
    }
