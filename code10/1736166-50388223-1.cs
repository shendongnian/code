    public class MyTextBox : TextBox
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button DelBtn = (Button)GetTemplateChild("Delete");
            DelBtn.Click += DelBtn_Click;
    
        }
        private async void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Clear All Text",
                Content = "Do you want clear all text?",
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Accept"
            };
            noWifiDialog.PrimaryButtonClick += NoWifiDialog_PrimaryButtonClick;
            await noWifiDialog.ShowAsync();
        }
    
        private void NoWifiDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Text = String.Empty;
        }
    
    }
