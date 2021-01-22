        public bool IsTimeString(string ts)
        {
            if (ts.Length == 5 && ts.Contains(':'))
            {
                int h;
                int m;
                return int.TryParse(ts.Substring(0, 2), out h) &&
                       int.TryParse(ts.Substring(3, 2), out m) &&
                       h >= 0 && h < 24 &&
                       m >= 0 && m < 60;
            }
            else
                return false;
        }
