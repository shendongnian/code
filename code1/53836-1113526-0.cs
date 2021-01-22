    class ToolSheet
    {
        
        //Not the prettyest but surely the fastest :
        static string[] ColName = new string[676];
        public ToolSheet()
        {
            ColName[0] = "A";
            for (int index = 1; index < 676; ++index) Recurse(index, index);
        }
        private int Recurse(int i, int index)
        {
            if (i < 1) return 0;
            ColName[index] = ((char)(65 + i % 26)).ToString() + ColName[index];
            return Recurse(i / 26, index);
        }
        public string GetColName(int i)
        {
            return ColName[i - 1];
        }
    }
