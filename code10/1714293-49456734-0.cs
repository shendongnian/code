    public static string HackerSort()
    {
        List<string> input = new List<string>() {"20"
                                                , "0 ab"
                                                , "6 cd"
                                                , "0 ef"
                                                , "6 gh"
                                                , "4 ij"
                                                , "0 ab"
                                                , "6 cd"
                                                , "0 ef"
                                                , "6 gh"
                                                , "0 ij"
                                                , "4 that"
                                                , "3 be"
                                                , "0 to"
                                                , "1 be"
                                                , "5 question"
                                                , "1 or"
                                                , "2 not"
                                                , "4 is"
                                                , "2 to"
                                                , "4 the" };
        List<string>[] wl = new List<string>[100];
        int n = int.Parse(input[0]);
        int half = n/2;
        char split = ' ';
        for (int i = 0; i < n; i++)
        {
            string s = input[i + 1];
            string[] ss = s.Split(split);
            //Debug.WriteLine(ss[0]);
            int row = int.Parse(ss[0]);
            if(wl[row] == null)
            {
                wl[row] = new List<string>((n / 100) + 1);
            }
            wl[row].Add(i  < half ? "-" : ss[1]);            
        }
        StringBuilder sb = new StringBuilder();
        foreach(List<string> ls in wl.Where(x => x != null))
        {
            sb.Append(string.Join(" ", ls) + ' ');
        }
        Debug.WriteLine(sb.ToString().TrimEnd());
        return sb.ToString().TrimEnd();
    }
