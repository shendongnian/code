        public static string MaskFirstName(string greeting)
        {
            string masked = "";
            // clean up the input string by removing any leading and trailing white spaces
            greeting = greeting.Trim();
            // index of the comma
            int commaInd = greeting.IndexOf(',');
            // get the name of the person
            string target = greeting.Substring(0, commaInd);
            // index of the first space
            int firstSpaceInd = target.IndexOf(' ');
            // index of the last space
            int lastSpaceInd = target.LastIndexOf(' ');
            // The indiviual chars of our target string
            char[] chars = target.ToCharArray();
            // replace the characters between the first space and the last space in our target string
            for (int i = firstSpaceInd + 1; i != lastSpaceInd; i++)
            {
                chars[i] = '*';
            }
            // rebuild our original input string with the masked name
            masked = greeting.Replace(target, new string(chars));
            return masked;
        }
    
