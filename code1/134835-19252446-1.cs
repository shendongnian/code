        static void Main(string[] args)
        {
            string strIn = System.Console.ReadLine();
            char[] chraryIn = strIn.ToCharArray();
            int iShift = 0;
            char chrTemp;
            for (int i = 0; i < chraryIn.Length; ++i)
            {
                if (i > 0)
                {
                    chrTemp = chraryIn[i];
                    chraryIn[i - iShift] = chrTemp;
                    chraryIn[i] = chraryIn[i - iShift];
                }
                if (chraryIn[i] == ' ') iShift++;
                if (i >= chraryIn.Length - 1 - iShift) chraryIn[i] = ' ';
            }
           System.Console.WriteLine(new string(chraryIn));
           System.Console.Read();
        }
