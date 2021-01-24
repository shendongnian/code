    private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        var viewModel = DataContext as YourViewModel;
        if (viewModel != null)
        {
            switch (e.Key)
            {
                case Key.D0:
                    viewModel.ShortcutCharacterCommand.Execute("0");
                    break;
                case Key.D1:
                    viewModel.ShortcutCharacterCommand.Execute("1");
                    break;
                    //...
            }
        }
    }
