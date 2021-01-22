    String TitleCaseString(String s)
    {
        if (s == null || s.Length == 0) return s;
        string[] splits = s.Split(' ');
        for (int i = 0; i < splits.Length; i++)
        {
            switch (splits[i].Length)
            {
                case 1:
                    break;
                default:
                    splits[i] = Char.ToUpper(splits[i][0]) + splits[i].Substring(1);
                    break;
            }
        }
        return String.Join(" ", splits);
    }
