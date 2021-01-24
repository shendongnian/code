    static string ReturnOdd(int[] tab, int i)
        {
            if (tab.Length == 0 || i >= tab.Length)
                return "";
            if (i == tab.Length - 1)
            {
                if (tab[i] % 2 != 0)
                    return Convert.ToString(tab[i]);
                else
                    return "";
            }
            if (tab[i] % 2 != 0)
            {
                string s = ReturnOdd(tab, i + 1);
                if (!String.IsNullOrEmpty(s))
                    s = "," + s;
                return Convert.ToString(tab[i] + s);
            }
            else
                return Convert.ToString(ReturnOdd(tab, i + 1));
        }
