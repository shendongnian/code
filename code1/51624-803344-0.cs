    public static void AddNewLineIfMatch(this RichTextBox rtb, string toMatch) {
      if ( rtb.Text == toMatch ) {
        rtb.AppendText("\n");
      }
    }
    PFDA(() => form.Richbox1.AddNewLineIfMatch("Test"));
