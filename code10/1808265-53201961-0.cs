    private async void btn2_Click(object sender, RoutedEventArgs e)
    {
        for(int i = 0; i<=10000000; i++)
        {
            textBlock2.Text = i.ToString();
            await Task.Delay(200); //stay 200 ms before showing next number so human eyes can see it.
        }
    }
