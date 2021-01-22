    class ToolSheet
    {
        //Not the prettyest but surely the fastest :
        static string[] ColName = new string[676];
        public ToolSheet()
        {
            for (int index = 0; index < 676; ++index)
            {
                Recurse(index, index);
            }
        }
        private int Recurse(int i, int index)
        {
            if (i < 1)
            {
                if (index % 26 == 0 && index > 0) ColName[index] = ColName[index - 1].Substring(0, ColName[index - 1].Length - 1) + "Z";
                return 0;
            }
            ColName[index] = ((char)(64 + i % 26)).ToString() + ColName[index];
            return Recurse(i / 26, index);
        }
        public string GetColName(int i)
        {
            return ColName[i - 1];
        }
    }
