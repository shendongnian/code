    private void CheckedChanged(object sender, EventArgs e)
            {
                CheckBox cb = sender as CheckBox;
                if (!cb.Checked)
                {
                    Console.WriteLine(cb.Text);
    
                }
            }
            
