    private string GeneratePassword(bool useCapitalLetters, bool useSmallLetters, bool useNumbers, bool useSymbols, int passLenght)
        {
            Random random = new Random();
            StringBuilder password = new StringBuilder(string.Empty);
            //This for loop is for selecting password chars in order 
            for (int i = 0;;)
            {
                if (useCapitalLetters)
                {
                    password.Append((char)random.Next(65, 91)); //Capital letters 
                    ++i; if (i >= passLenght) break;
                }
                if (useSmallLetters)
                {
                    password.Append((char)random.Next(97, 122)); //Small letters
                    ++i; if (i >= passLenght) break;
                }
                if (useNumbers)
                {
                    password.Append((char)random.Next(48, 57)); //Number letters
                    ++i; if (i >= passLenght) break;
                }
                if (useSymbols)
                {
                    password.Append((char)random.Next(35, 38)); //Symbol letters
                    ++i; if (i >= passLenght) break;
                }
            }
            //This for loop is for disordering password characters
            for (int i = 0; i < password.Length; ++i)
            {
                int randomIndex1 = random.Next(password.Length);
                int randomIndex2 = random.Next(password.Length);
                char temp = password[randomIndex1];
                password[randomIndex1] = password[randomIndex2];
                password[randomIndex2] = temp;
            }
            return password.ToString();
        }
