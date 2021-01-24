    private void generate_Click(object sender, EventArgs e)
    {            
        RichTextBox text = new RichTextBox();
        Button delete = new Button();
        m_Control = text;
    
        this.Controls.Add(text);
        this.Controls.Add(delete);
        i++;
    }
