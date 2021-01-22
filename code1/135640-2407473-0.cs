    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("$"))
            {
                string[] str_split = textBox1.Text.Split("$".ToCharArray ());
                textBox1.Text = str_split[0].ToString ();
                textBox2.Text = str_split[1].ToString();
            }
        }
