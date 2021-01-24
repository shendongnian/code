    private void Textbox1_TextChanged(object sender, EventArgs e)
    {
      this.Textbox1.AutoCompleteMode = 
      System.Windows.Forms.AutoCompleteMode.Suggest;
      var t = Textbox1.Text;
    }
