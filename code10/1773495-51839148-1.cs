    private void Test_Click(object sender, RoutedEventArgs e)
    {
        ModelTextView nd = DataContext as ModelTextView;
        nd.Ricevi(Send.Text);
        this.Close();
    }
