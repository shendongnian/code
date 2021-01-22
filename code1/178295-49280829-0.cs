                //password rules 
                int minUpper = 3;
                int minLower = 3;
                int minLength = 8;
                int maxLength = 12;
                string allowedSpecials = "@#/.!')";
    
                //entered password
                string enteredPassword = "TEStpass123@";
    
                //get individual characters
                char[] characters = enteredPassword.ToCharArray();
    
                //checking variables
    
                int upper = 0;
                int lower = 0;
                int character = 0;
                int number = 0;
                int length = enteredPassword.Length;
                int illegalCharacters = 0;
    
    
                //check the entered password
                foreach (char enteredCharacters in characters)
                {
                    if (char.IsUpper(enteredCharacters))
                    {
                        upper = upper + 1;
                    }
                    else if (char.IsLower(enteredCharacters))
                    {
                        lower = lower + 1;
                    }
                    else if (char.IsNumber(enteredCharacters))
                    {
                        number = number + 1;
                    }
                    else if (allowedSpecials.Contains(enteredCharacters.ToString()))
                    {
                        character = character + 1;
                    }
                    else
                    {
                        illegalCharacters = illegalCharacters + 1;
                    }
    
                    // MessageBox.Show(chars.ToString());
                }
    
                if (upper < minUpper || lower < minLower || length < minLength || length > maxLength || illegalCharacters >=1)
                {
                    MessageBox.Show("Something's not right, your password does not meet the minimum security criteria");
                }
                else
                {
                    //code to proceed this step
                }
      
        
        
    
     
