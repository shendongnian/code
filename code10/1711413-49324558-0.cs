    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (await CheckLogin())
        {
            Step02();
        }
        else
        {
            MessageBox.Show(ErrorMessage)
        }
    }
    private async Task<bool> CheckLogin()
    {
        return await Task.Run(() =>
        {
            //this code runs on a background thread...
            Thread.Sleep(5000);
            return true;
        });
    }
