    private async void losBtn_Click(object sender, RoutedEventArgs e)
    {
        for (int i = LstFiles.Count - 1; i >= 0; i--)
        {
            LstFiles.RemoveAt(i);
            await Task.Delay(50);
        }   
    }
