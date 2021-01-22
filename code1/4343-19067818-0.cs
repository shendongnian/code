     private void button1_Click(object sender, EventArgs e)
        {
        // This clears the textBox, resets the count, and starts the timer
            count = 0;
            textBox1.Clear();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        // This generates the password, and types it in the textBox
            count += 1;
                string possible = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string psw = "";
                Random rnd = new Random { };
                psw += possible[rnd.Next(possible.Length)];
                textBox1.Text += psw;
                if (count == (comboBox1.SelectedIndex + 1))
                {
                    timer1.Stop();
                }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // This adds password lengths to the comboBox to choose from.
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("6");
            comboBox1.Items.Add("7");
            comboBox1.Items.Add("8");
            comboBox1.Items.Add("9");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("11");
            comboBox1.Items.Add("12");
        }
        private void button2_click(object sender, EventArgs e)
        {
            // This encrypts the password
            tochar = textBox1.Text;
            textBox1.Clear();
            char[] carray = tochar.ToCharArray();
            for (int i = 0; i < carray.Length; i++)
            {
                int num = Convert.ToInt32(carray[i]) + 10;
                string cvrt = Convert.ToChar(num).ToString();
                textBox1.Text += cvrt;
            }
        }
