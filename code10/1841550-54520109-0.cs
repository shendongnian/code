    private async void Form1_Load(object sender, EventArgs e)
    {
        serialPort1.Open();
        using (var reader = new StreamReader(serialPort1.BaseStream)) {
             while (serialPort1.IsOpen) {
                 string x = await reader.ReadLineAsync();
                 textBox2.AppendText(x + "\r\n");
             }
        }
    }
