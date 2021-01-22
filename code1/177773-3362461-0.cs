    or (int i = 65; i <= 90; i++)
            {
                LinkButton lbtnCharacters = new LinkButton();
                lbtnCharacters.Text = "<u>" + Char.ConvertFromUtf32(i) + "</u>";
                lbtnCharacters.ID = Char.ConvertFromUtf32(i);
                lbtnCharacters.CommandArgument = Char.ConvertFromUtf32(i);
                lbtnCharacters.CommandName = "AlphaPaging";
                lbtnCharacters.CssClass = "firstCharacter";
                lbtnCharacters.Click += new EventHandler(lbtnAlphabets_Click);
                alphabets.Controls.Add(lbtnCharacters);
    
                // add this
                alphabetLinkButtons.Add(lbtnCharacters);
    
    
            }
