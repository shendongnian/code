    StringBuilder strbld = new StringBuilder();
        
    for (int i = 0; i < this.richTextBox1.Text.Length; i++)
    {
       char c = this.richTextBox1.Text[i];
       
       if (c.ToString() != "\n")
          strbld.Append(c);
    }
    MessageBox.Show(strbld.ToString());
