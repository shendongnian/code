            public static string MaskFirstName(string greeting)
            {
            // index of the first space
            int firstSpaceInd = greeting.IndexOf(' ');
            // index of the comma
            int commaInd = greeting.IndexOf(',');
            // The indiviual chars in our greeting
            char[] chars = greeting.ToCharArray();
            // replace the characters between the first and last spaces
            for (int i = firstSpaceInd + 1; i != commaInd; i++)
            {
                chars[i] = '*';
            }
            return new string(chars);
         }
