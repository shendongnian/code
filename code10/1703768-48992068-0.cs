    public static bool ValidateString(string string1)
        {
            List<string> invalidChars = new List<string>() { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" };
            // Check for length
            if (string1.Length > 100)
            {
                Console.WriteLine("String too Long");
                return false;
            }
            else if (!(!string1.Equals(string1.ToLower())))
            {
                //Check for min 1 uppercase
                Console.WriteLine("Requres at least one uppercase");
                return false;
            }
            else 
            {
                     //Iterate your list of invalids and check if input has one
                foreach(string s in invalidChars)
                {
                     if(string1.Contains(s))
                     {
                        Console.WriteLine("String contains invalid character: " + s);
                        return false;
                     }
                  }
                    Console.WriteLine("All tests succesful");
                    return true;
            }
        }
