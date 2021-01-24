    private async void PipBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = PipBox.Text;
        await CoreApplication.MainView.Dispatcher.AwaitableRunAsync(() =>
        {
            if (parentBox.Text != text)
                parentBox.Text = text;
        });
    }
    private async void ParentBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = parentBox.Text;
        // the awaitablerunasync extension method comes from "Windows Community Toolkit".
        await _viewLifetimeControl.Dispatcher.AwaitableRunAsync(() =>
        {
            if (ViewModel.MyNote.Description != text)
                ViewModel.MyNote.Description = text;
        });
    }
