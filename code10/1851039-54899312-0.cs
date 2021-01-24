        private async void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var title = "title";
            var text = "text";
            var closeButtonText = "close";
            ContentDialog dialog = new ContentDialog()
            {
                Title = title,
                Content = text,
                CloseButtonText = closeButtonText
            };           
            dialog.Background = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));
            await dialog.ShowAsync();
        }
