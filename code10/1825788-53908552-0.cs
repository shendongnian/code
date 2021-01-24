    public void SaveData()
    {
       File.WriteAllText($"{textBox1.Text},{textBox2.Text},{textBox3.Text}");
    }
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
       SaveData();
    }
