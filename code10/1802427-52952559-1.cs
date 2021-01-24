    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        if (mainWindow != null)
        {
            label1.Content = mainWindow.textBox1.Text;
            label2.Content = mainWindow.textBox2.Text;
        }
    }
