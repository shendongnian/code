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
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(
                "Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
            {
                // check that this API is available on the user’s machine
                dialog.Background = new AcrylicBrush()
                {
                    BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop,
                    TintOpacity = 0.5,
                    FallbackColor = Color.FromArgb(255, 202, 24, 37),
                    Opacity = 0.5,
                };
            }
            await dialog.ShowAsync();
        }
