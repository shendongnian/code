    private void Textbox_TextChanged(object sender, EventArgs e)
    {
      this.textbox.AutoCompleteMode = 
      System.Windows.Forms.AutoCompleteMode.Suggest;
      var t = textbox.Text;
    }
