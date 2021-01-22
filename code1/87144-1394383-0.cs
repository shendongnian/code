    using (StreamReader reader = new StreamReader(new FileStream("yourFileName.txt", FileMode.Open, FileAccess.Read)))
    {
        textBox1.Text = reader.ReadLine();
        textBox2.Text = reader.ReadLine();
        textBox3.Text = reader.ReadLine();
        textBox4.Text = reader.ReadLine();
        textBox5.Text = reader.ReadLine();
        textBox6.Text = reader.ReadLine();
        textBox7.Text = reader.ReadLine();
        textBox8.Text = reader.ReadLine();
        textBox9.Text = reader.ReadLine();
    }
