        private void richTextBox1_keyDown(object sender, KeyEventArgs e)
        {
            
            for (int i = 0; i <= richTextBox1.Lines.Count(); i++)
            {
                if (!(e.KeyCode == Keys.Back))
                {
                    if (!richTextBox2.Text.Contains(i.ToString()))
                    {
                        richTextBox2.Text += i.ToString() + "\n";
                    }
                }
                else
                {
                    richTextBox2.Clear();
                }
            }    
        } 
