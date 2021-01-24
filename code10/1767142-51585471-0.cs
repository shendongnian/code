    private void button2_Click(object sender, EventArgs e)
    {
        Form2 f2 = new Form2();
        System.Threading.Tasks.Task.Run(() =>
        {
            if (f2.ShowDialog() == DialogResult.OK)
            {
                // do here whatever you want to do
                MessageBox.Show("Form2 closed");
            }
        });
    }
