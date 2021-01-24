    private void addAnInteger_Error(object sender, ValidationErrorEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        textBox.Dispatcher.BeginInvoke(new Action(() => { Keyboard.Focus(textBox); }), System.Windows.Threading.DispatcherPriority.Background);
    }
