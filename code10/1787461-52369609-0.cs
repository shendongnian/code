        public int BiggestNumberInString(string input)
        {
            return input.Split(null).Max(x => int.Parse(x));
        }
    only if you are sure of your input
