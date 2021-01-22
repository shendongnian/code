    private void textBox_BiggerThan_TextChanged(object sender, EventArgs e)
            {
                long a;
                if (! long.TryParse(textBox_BiggerThan.Text, out a))
                {
               // If Not Integer Clear Textbox text or you can also Undo() Last Operation :)
                    textBox_LessThan.Clear();
                }
            }
:) 
