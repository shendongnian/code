    private void BtnShowNotes_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        if (mw != null)
            mw.FrContent.Content = new Page_Notes();
    }
