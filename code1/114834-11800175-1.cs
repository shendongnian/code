        public string UppercaseFirstEach(string s)
        {
            char[] a = s.ToLower().ToCharArray();
            for (int i = 0; i < a.Count(); i++ )
            {
                a[i] = i == 0 || a[i-1] == ' ' ? char.ToUpper(a[i]) : a[i];
            }
            return new string(a);
        }
