        private void btn_Click(object sender, RoutedEventArgs e)
        {
            btn.Visibility = Visibility.Collapsed;
            btn.Visibility = Visibility.Visible;
            Debug.WriteLine("Button Clicked "+ e.OriginalSource.ToString());
        }
        private void WebView_GotFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Webview got focus");
        }
