        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string Message = "test.";
            string Title = "Testing message dialog.";
            var messageDialog = new Windows.UI.Popups.MessageDialog(Message, Title);
            messageDialog.Commands.Add(new UICommand("commandtext", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();
        }
        private void CommandInvokedHandler(IUICommand command)
        {
            CommandInvoked.Text = "CommandInvokedHandler invoked.";
        }
