             private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                label1.Text = string.Empty;
                string[] arr = textBox1.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                    label1.Text += arr[i] + "\r\n";
            }
        } 
