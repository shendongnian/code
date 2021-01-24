    private void button6_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(textBox2.Text);
        File.WriteAllText(@"c:\Ebaycodes\kk.txt", textbox2.Text);
    }
