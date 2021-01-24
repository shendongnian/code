    private void generate_Click(object sender, EventArgs e)
    {            
      RichTextBox text = new RichTextBox();
      Button delete = new Button();
      this.Controls.Add(text);
      this.Controls.Add(delete);
      i++;
      //---- Remove Part --------
      this.Controls.Remove(text);
      //------------------------
    }
