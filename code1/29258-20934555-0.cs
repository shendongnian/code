        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox1.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox1.Text = actualdata;
        }
