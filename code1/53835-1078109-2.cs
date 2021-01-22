        static Dictionary<int, string> LetterDict = new Dictionary<int, string>(676);
        public static string LetterWithCaching(int index)
        {
            int intCol = index - 1;
            if (LetterDict.ContainsKey(intCol)) return LetterDict[intCol];
            int intFirstLetter = ((intCol) / 676) + 64;
            int intSecondLetter = ((intCol % 676) / 26) + 64;
            int intThirdLetter = (intCol % 26) + 65;
            char FirstLetter = (intFirstLetter > 64) ? (char)intFirstLetter : ' ';
            char SecondLetter = (intSecondLetter > 64) ? (char)intSecondLetter : ' ';
            char ThirdLetter = (char)intThirdLetter;
            String s = string.Concat(FirstLetter, SecondLetter, ThirdLetter).Trim();
            LetterDict.Add(intCol, s);
            return s;
        }
