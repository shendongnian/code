    public static string GeneratePassword(int Length, int NonAlphaNumericChars)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            string allowedNonAlphaNum = "!@#$%^&*()_-+=[{]};:<>|./?";
            Random rd = new Random();
            if (NonAlphaNumericChars > Length || Length <= 0 || NonAlphaNumericChars < 0)
                throw new ArgumentOutOfRangeException();
                char[] pass = new char[Length];
                int[] pos = new int[Length];
                int i = 0, j = 0, temp = 0;
                bool flag = false;
                //Random the position values of the pos array for the string Pass
                while (i < Length - 1)
                {
                    j = 0;
                    flag = false;
                    temp = rd.Next(0, Length);
                    for (j = 0; j < Length; j++)
                        if (temp == pos[j])
                        {
                            flag = true;
                            j = Length;
                        }
                    if (!flag)
                    {
                        pos[i] = temp;
                        i++;
                    }
                }
                //Random the AlphaNumericChars
                for (i = 0; i < Length - NonAlphaNumericChars; i++)
                    pass[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                //Random the NonAlphaNumericChars
                for (i = Length - NonAlphaNumericChars; i < Length; i++)
                    pass[i] = allowedNonAlphaNum[rd.Next(0, allowedNonAlphaNum.Length)];
                //Set the sorted array values by the pos array for the rigth posistion
                char[] sorted = new char[Length];
                for (i = 0; i < Length; i++)
                    sorted[i] = pass[pos[i]];
                string Pass = new String(sorted);
                return Pass;
        }
