        //Symb array
        private const string _SymbolsAll = "~`!@#$%^&*()_+=-\\|[{]}'\";:/?.>,<";
        //Random symb
        public string GetSymbol(int Length)
        {
            Random Rand = new Random(DateTime.Now.Millisecond);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Length; i++)
                result.Append(_SymbolsAll[Rand.Next(0, _SymbolsAll.Length)]);
            return result.ToString();
        }
