    static string join(string a,string b)
    {
        for (var i=0;i<a.Length;i++)
        {
            if (b.IndexOf(string.Join("", a.ToArray().Skip(i))) == 0)
            {
                return a + string.Join("", b.ToArray().Skip(a.Length - i));
            }
        }
        return a + b;
    }
