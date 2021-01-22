        private void button1_Click(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                Console.WriteLine("Do checkBox1 thing.");
            }
            if (checkBox2.Checked) {
                Console.WriteLine("Do checkBox2 thing.");
            }
            if (!checkBox1.Checked && !checkBox2.Checked) {
                Console.WriteLine("Do something since neither checkBox1 and checkBox2 are checked.");
            }
        }
