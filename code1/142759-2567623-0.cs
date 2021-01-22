    private static int Count1(string s)
    {
        int len = s.Length;
        int c = 0;
        for (int i=0; i < len;  i++)
        {
            if (s[i] == '\n') c++;
        }
        return c+1;
    }
    private static int Count2(string s)
    {
        int count = -1;
        int index = -1;
        do
        {
            count++;
            index = s.IndexOf('\n', index + 1);
        }
        while (index != -1);
        return count+1;
    }
    private static int Count3(string s)
    {
        return s.Count( c => c == '\n' ) + 1;
    }
    private static int Count4(string s)
    {
        int n = 0;
        foreach( var c in s )
        {
            if ( c == '\n' ) n++;
        }
        return n+1;
    }
    private static int Count5(string s)
    {
        var a = s.ToCharArray();
        int c = 0;
        for (int i=0; i < a.Length; i++)
        {
            if (a[i]=='\n') c++;
        }
        return c+1;
    }
