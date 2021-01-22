        private string DatabasePassword(string userPassword)
        {
            //Constants showing mapping between user password and database password
            const string userChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string dbChars   = "9setybcpqwiuvxr108daj5'-`~!@#$%^&()+|}][{:.?/<>,;ZWQ2@#34KDABC";
            
            //Stringbuilder used to build the database password for output
            System.Text.StringBuilder databasePassword = new System.Text.StringBuilder();
            //Run through every character in the user password
            foreach (Char userChar in userPassword)
            {
                //Find the index of the user character in the userChars string.
                int userCharIndex = userChars.IndexOf(userChar);
                //if the userChar exists in the userChars string then map the character to the
                //equivalent database pasword character else just use the entered char
                char mappedChar = userCharIndex >= 0 ? dbChars[userChars.IndexOf(userChar)] : userChar;
                //Append mapped password to the output database password
                databasePassword.Append(mappedChar);
            }
            return databasePassword.ToString();
        }
