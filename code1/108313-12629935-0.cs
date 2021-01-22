    FocusedNodeChanged += OnNodeChanged;
    private void OnNodeChanged(object s, FocusedNodeChangedEventArgs e)
        {
            _delayer.Start();
        }
    private void _delayer_Tick(object sender, EventArgs e)
        {
            ShowEditor();
            _delayer.Stop();
        }
