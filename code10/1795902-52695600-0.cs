       public void KeyPress(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.Key == Key.Enter)
                    {
                        MessageBox.Show("Enter Key Pressed!");
                    }
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
