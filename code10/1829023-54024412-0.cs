    char[] splittedText;
    string test = "narmin";
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        splittedText = new char[test.Length];
        for (int i =0 ; i<test.Length;i++)
        {
           splittedText[i] = test[i];
        }
    }
