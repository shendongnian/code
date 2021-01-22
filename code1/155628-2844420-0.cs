    private void UTextBox_TextChanged(object sender, EventArgs e)
    {
        string lastCharacter = this.Text[this.Text.Length-1].ToString();
        MatchCollection matches = Regex.Matches(lastCharacter, "[0-9]", RegexOptions.None);
        if (matches.Count > 0) //character is a number, reject it.
        {
             this.Text = Text.Substring(0, Text.Length-1);
        }
     }
     
 
