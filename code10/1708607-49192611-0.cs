        public class CustomComparer : IComparer<string>
        {
            Dictionary<string, int> colorPriorities;
            public CustomComparer()
            {
                colorPriorities = new Dictionary<string, int>();
                colorPriorities.Add("GY", 1);
                colorPriorities.Add("BL", 2);
                colorPriorities.Add("RD", 4);
                colorPriorities.Add("BK", 8);
            }
            public int GetPriority(string color)
            {
                if (!colorPriorities.ContainsKey(color))
                {
                    return 5;
                }
                return colorPriorities[color];
            }
            public int Compare(string x, string y)
            {
                string xSortKeyColor = x.Split(';')[2];
                double xSortKeySection = Convert.ToDouble(x.Split(';')[1]);
                double xSortKeyLenght = Convert.ToDouble(x.Split(';')[3]);
                string ySortKeyColor = y.Split(';')[2];
                double ySortKeySection = Convert.ToDouble(y.Split(';')[1]);
                double ySortKeyLenght = Convert.ToDouble(y.Split(';')[3]);
                if (xSortKeyColor != ySortKeyColor)
                    return GetPriority(xSortKeyColor).CompareTo(GetPriority(ySortKeyColor));
                if (xSortKeySection != ySortKeySection)
                    return xSortKeySection.CompareTo(ySortKeySection);
                return xSortKeyLenght.CompareTo(ySortKeyLenght);
            }
        }
