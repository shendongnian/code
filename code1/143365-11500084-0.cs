    bool bV=false;
        private void textBox1_Validated(object sender, EventArgs e)
        {
            TextBox textBoxText = sender as TextBox;
            if (!textBoxText.Equals(String.Empty))  
            {
                foreach (char c in textBoxText.Text.ToArray())
                {
                    if (!Char.IsDigit(c))
                    {
                        if (!bV)
                        {
                            MessageBox.Show("Input value not valid plase Insert Integer Value");
                            bV = true;
                            textBox1.Text = String.Empty;
                            break;
                        }
                    }
                }
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bV = false;
        }
