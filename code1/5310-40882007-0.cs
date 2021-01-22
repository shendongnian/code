            if (!string.IsNullOrEmpty(input))
            {
                string[] arrUserInput = input.Split(' ');
                // Initialize a string builder object for the output
                StringBuilder sbOutPut = new StringBuilder();
               
                // Loop thru each character in the string array
                foreach (string str in arrUserInput)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        var charArray = str.ToCharArray();
                        int k = 0;
                        foreach (var cr in charArray)
                        {
                            char c;
                            c = k == 0 ? char.ToUpper(cr) : char.ToLower(cr);
                            sbOutPut.Append(c);
                            k++;
                        }
                      
                        
                    }
                    sbOutPut.Append(" ");
                }
                return sbOutPut.ToString();
            }
            return string.Empty;
        }
