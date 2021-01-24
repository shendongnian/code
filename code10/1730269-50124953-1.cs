    private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var textLength = richTextBox1.TextLength;
            l6.Text = @"{textLength}/300";
            
            // Add ranges in condition and set color.
            if (textLength ==0)
            {
                l6.ForeColor = Color.Red; //Whatever color
            }
            else if (textLength > 275)
            {
                l6.ForeColor = Color.Red;
            }
            else if (textLength < 274)
            {
                l6.ForeColor = Color.Red;
            }
        }
