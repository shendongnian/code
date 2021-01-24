    // Credentials has type (string, string)[]
    var credentials = new (string name, string pass)[] { ("name1", "pass1"), ("name2", "pass2") };
    if (credentials.Any(c => textBox1.Text == c.name && textBox2.Text == c.pass))
    {
        MessageBox.Show("Success");
    }
