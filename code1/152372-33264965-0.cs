            private void textBox_TextChanged(object sender, EventArgs e)
        {
            string c = "";
            string d = "0123456789.";
            foreach (char a in textBox.Text)
            {
                if (d.Contains(a))
                    c += a;
            }
            textBox.Text = c;
            textBox.SelectionStart = textBox.Text.Length;
        }
