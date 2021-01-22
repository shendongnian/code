    private SemaphoreSlim _lockMoveButton = new SemaphoreSlim(1);
    private async void btnMove_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (_lockMoveButton.Wait(0) && button != null)
        {
            try
            {                    
                button.IsEnabled = false;
            }
            finally
            {
                _lockMoveButton.Release();
                button.IsEnabled = true;
            }
        }
    }
