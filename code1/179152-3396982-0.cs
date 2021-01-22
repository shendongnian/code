    private void button1_Click(object sender, EventArgs e)
    {
        saveFileDialog1.Filter = "Xml Document (.asdf.xml)|*.asdf.xml";
        saveFileDialog1.ShowDialog();
        System.IO.FileStream fs = saveFileDialog1.OpenFile() as System.IO.FileStream;
        fs.Write(new byte[] { }, 0, 0);
        fs.Close();
    }
