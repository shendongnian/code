    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.WriteAllText(@"C:\Users\MYPC\Desktop\trial.txt", textBox1.Text);
                MessageBox.Show("Save to textfilet trial...");
                System.IO.File.WriteAllText(@"C:\Users\MYPC\Desktop\temp.txt", textBox2.Text);
                MessageBox.Show("Save to textfile.. temp.");
            }
            catch (Exception ex)
            {
                //LOG>?!
                throw ex;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int file1IntVal = int.Parse(System.IO.File.ReadAllText(@"C:\Users\MYPC\Desktop\trial.txt"));
                int file2IntVal = int.Parse(System.IO.File.ReadAllText(@"C:\Users\MYPC\Desktop\temp.txt"));
                textBox3.Text = file1IntVal + file2IntVal;
            }
            catch (Exception ex)
            {
                //LOG>?!
                throw ex;
            }
        }
