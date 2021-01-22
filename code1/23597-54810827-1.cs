           private void lastinput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
            catch
            {
            }
        }
