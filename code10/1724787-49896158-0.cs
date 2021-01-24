    string s = textBox_Ansprechpartner_Name.Text;
    //shouldn't be necessary    
    //if (string.IsNullOrEmpty(s)) return;
    foreach (var c in s)
        if (!char.IsLetter(c))
        {
            textBox_Ansprechpartner_Name.Text = "":
            MessageBox.Show("This textbox may only contain letters.");
            return;
        }
