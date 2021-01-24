    async void PasteButton_Click(object sender, RoutedEventArgs e)
    {
        var data = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
        if (data.Contains(StandardDataFormats.Html))
        {
            string htmlFormat = null;
            {
                htmlFormat = await data.GetHtmlFormatAsync();
            }
        }
    }
