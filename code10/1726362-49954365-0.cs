    var filenames;
    private void button1_Click(object sender, EventArgs e)
            {
                filenames = Directory.GetFiles("C:/Users/Example/Desktop/folder");
            }
    private void button2_Click(object sender, EventArgs e)
            {
                textBox1.Lines = filenames
            }
