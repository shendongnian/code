    private void Button_Click(object sender, RoutedEventArgs e)
        {
            someTextBox.Clear();
            new Thread(MyTread).Start();
            (sender as Button).Content = "Thread started";
        }
        private void MyTread()
        {
            someTextAdd("Some text\n");
            Thread.Sleep(1000);
            someTextAdd("Some text\n");
            Thread.Sleep(1000);
            someTextAdd("Some text\n");
            Thread.Sleep(1000);
            someTextAdd("Some text\n");
            Thread.Sleep(1000);
        }
        private void someTextAdd(string text)
        {
            someTextBox.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background,
            new Action(() =>
            {
                someTextBox.Text += text;
            }));
        }
