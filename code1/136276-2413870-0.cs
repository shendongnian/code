    private void button1_Click(object sender, EventArgs e)
    {
        int foo;
        int bar;
        if ( ! Int32.TryParse(textBox1.Text, out foo))
        {
            MessageBox.Show("Foo must be a number!");
            return;
        }
        if ( ! Int32.TryParse(textBox2.Text, out bar))
        {
            MessageBox.Show("Bar must be a number!");
            return;
        }
        // do something with foo and bar
    }
