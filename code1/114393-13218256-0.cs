     private void textbox1_TextChanged(object sender, EventArgs e)
            { 
                char[] originalText = textbox1.Text.ToCharArray();
                foreach (char c in originalText)
                {
                    if (!(Char.IsNumber(c)))
                    {
                        textbox1.Text = textbox1.Text.Remove(textbox1.Text.IndexOf(c));
                        lblError.Visible = true;
                    }
                    else
                        lblError.Visible = false;
                }
                textbox1.Select(textbox1.Text.Length, 0);
            }
