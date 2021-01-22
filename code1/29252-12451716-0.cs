    void TextBox_KeyDown(object sender, KeyEventArgs e)
            {
                char c = Convert.ToChar(e.PlatformKeyCode);
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                }
            }
