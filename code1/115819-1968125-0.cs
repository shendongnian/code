        private void demo()
            {
                string cell = "ABCD4321";
                int row, a = getIndexofNumber(cell);
                string Numberpart = cell.Substring(a, cell.Length - a);
                row = Convert.ToInt32(Numberpart);
                string Stringpart = cell.Substring(0, a);
            }
    
            private int getIndexofNumber(string cell)
            {
                int indexofNum=-1;
                foreach (char c in cell)
                {
                    indexofNum++;
                    if (Char.IsDigit(c))
                    {
                        return indexofNum;
                    }
                 }
                return indexofNum;
            }
