    private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (sender is TextBox)
                {
                    TextBox textBox = (TextBox)sender; 
                    if (e.Key == Key.Left || e.Key == Key.Right)
                    {
                        e.Handled = true; 
                        char insert; 
                        if (e.Key == Key.Left) 
                        { 
                            textBox1.SelectionStart = textBox1.Text.Length + 1; 
                            insert = '.';
                        }
                        else
                        { 
                            insert = '-';
                        } 
                        int i = textBox.SelectionStart;
                        textBox1.Text = textBox1.Text.Insert(i, insert.ToString());
                        textBox1.Select(i + 1, 0);
                    }
                }
            }
