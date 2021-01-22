    //Form1
     public void FindNext(Form2 frm2)
    {
        try
        {
            this.Focus();
            string s = frm2.textBox1.Text;
            richTextBox1.Focus();
            findPos = richTextBox1.Find(s, findPos, RichTextBoxFinds.None);
            richTextBox1.Select(findPos + 1, s.Length);
            findPos += textBox1.Text.Length;
        }
        catch
        {
            MessageBox.Show("No Occurences Found");
            findPos = 0;
        }
    }
    //Form2
     private void button1_Click(object sender, EventArgs e)
     {
        Form1 frm1 = new Form1();
        frm1.FindNext(this);
     }
