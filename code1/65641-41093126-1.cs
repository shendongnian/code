    public static string PrevExecelColumn( string s)
        {
            s = s.ToUpper();
            char[] ac = s.ToCharArray();
            int ln = ac.Length;
            for (int i = ln - 1; i > -1; i--)
            {
                char c = ac[i];
                if (c == 'A')
                {
                    ac[i] = 'Z';
                    continue;
                }
                ac[i] = (char)(((int)ac[i]) - 1);
                break;
            }
            s = new string(ac);
            return s;
       }  
     
