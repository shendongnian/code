    private void Page_KeyDown(object sender, KeyEventArgs e)
    {
        // If leftCtrl + T is pressed autofill username
        if (Keyboard.IsKeyDown(Key.T) && Keyboard.IsKeyDown(Key.LeftCtrl))
        {
            txtUser.Text = "My AutoFilled UserName";
            e.Handled = true;
        }
    }
