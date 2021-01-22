        public string Search(IEnumerable<string> values)
        {
            foreach(string value in values)
            {
                if(SomeArbitraryCondition())
                    return value;
            }
            return null;
        }
        public int PerformAction()
        {
            if (SomeArbitraryCondition())
            {
                if (SomeArbitraryCondition())
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                if (SomeArbitraryCondition())
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
        }
