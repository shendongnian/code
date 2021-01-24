            private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2=new Form2();
            f2.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            f2.ShowDialog();
        }
         void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("my code");
        }
