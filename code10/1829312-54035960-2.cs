    private void button1_Click(object sender, EventArgs e)
    {
       string IsNumberInStringFormat = TextBoxForEnteringANumber.Text;
    
       int IsNumber = 0;
    
       bool Check = int.TryParse(IsNumberInStringFormat, out IsNumber);
       string IsNotNumber = "Invalid Number";
    
       if (Check)
       {
          // IsNumber is not in Integer format.
          LabelForDisplayOutput.Text = IsNumber.ToString();
       }
       // I am Converting Number back to string for just a demonstration.
       LabelForDisplayOutput.Text = IsNumber.ToString(); 
       else
       {
          Char[] allCharacters = IsNumberInStringFormat.ToCharArray();
          foreach (var singleCharacter in allCharacters)
          {
             bool anotherCheck = int.TryParse(singleCharacter.ToString(), out IsNumber);
             if (anotherCheck)
             {
                LabelForDisplayOutput.Text += "\n";
                LabelForDisplayOutput.Text  += IsNumber.ToString();
             }
             else
             {
                LabelForDisplayOutput.Text += "\n";
                LabelForDisplayOutput.Text += "Invalid Character: " + singleCharacter;
             }
    
          }
       }
    }
