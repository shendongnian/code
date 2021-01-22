     // Prevent user from wrong input - \/:*?"<>|
            private void textBoxMP3Name_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^?:\\/:*?\""<>|]"))                                                                                        
                {                                                                           
                    e.Handled = true;
                }
            }
