        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.FormClosed += CloseListener;
            f2.Show();
        }
    
        private void CloseListener(object sender, EventArgs e)
        {
            Console.WriteLine("Form2 is closed");
        }
