        public string Search(IEnumerable<string> values)
        {
            string found = null;
            foreach(string value in values)
            {
                if(SomeArbitraryCondition())
                    found = value;
            }
            return found;
        }
        public int PerformAction()
        {
            int state;
            if (SomeArbitraryCondition())
            {
                if (SomeArbitraryCondition())
                {
                    state = 1;
                }
                else
                {
                    state = 2;
                }
            }
            else
            {
                if (SomeArbitraryCondition())
                {
                    state = 3;
                }
                else
                {
                    state = 4;
                }
            }
            return state;
        }
