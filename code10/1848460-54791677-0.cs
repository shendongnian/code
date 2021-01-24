                    string text = richTextBox1.Text;
                    foreach (var line in richTextBox1.Lines)
                    {
                        if (line.Contains("#"))
                        {
                            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
        
                            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
        
                            richTextBox1.Select(firstcharindex, 10);
        
                            richTextBox1.SelectionColor = Color.Red;
        
                            richTextBox1.DeselectAll();
                            richTextBox1.Select(richTextBox1.Text.Length, 0);
                        }
                        else
                        {
                            int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
        
                            int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
        
                            richTextBox1.Select(firstcharindex, 10);
        
                            richTextBox1.SelectionColor = Color.Black;
        
                            richTextBox1.DeselectAll();
                            richTextBox1.Select(richTextBox1.Text.Length, 0);
                        }
                     }
