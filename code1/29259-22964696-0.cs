    public void Check_If_Int_On_TextChanged(object sender, EventArgs e)
    {
       // This method checks that each inputed character is a number. Any non-numeric
       // characters are removed from the text
       TextBox textbox = (TextBox)sender;
       // If the text is empty, return
       if (textbox.Text.Length == 0) { return; }
       // Check the new Text value if it's only numbers
       byte parsedValue;
       if (!byte.TryParse(textbox.Text[(textbox.Text.Length - 1)].ToString(), out parsedValue))
       {
          // Remove the last character as it wasn't a number
          textbox.Text = textbox.Text.Remove((textbox.Text.Length - 1));
          // Move the cursor to the end of text
          textbox.SelectionStart = textbox.Text.Length;
        }
     }
