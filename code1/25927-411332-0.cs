    class MyUserControl
    {
      // expose the Text of the richtext control (read-only)
      public string TextOfRichTextBox
      {
        get { return richTextBox.Text; }
      }
      // expose the Checked Property of a checkbox (read/write)
      public bool CheckBoxProperty
      {
        get { return checkBox.Checked; }
        get { checkBox.Checked = value; }
      }
      
      //...
    }
