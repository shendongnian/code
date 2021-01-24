    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var txt = textBox1.Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(txt, "[^0-9]"))
            {
                for (int i = 0; i < txt.Length; i++)
                    if (!char.IsDigit(txt[i]))
                        if (i != txt.Length - 1)
                        {
                            //If he pasted a letter inclusive string which includes letters in the middle
                            //Remove the middle character or remove all text and request number as input
                            //I did the second way
                            textBox1.Text = "";
                            break;
                        }
                        else
                        {
                            //If he just typed a letter in the end of the text
                            textBox1.Text = txt.Substring(0, txt.Length - 1);
                            break;
                        }
            }
    }
