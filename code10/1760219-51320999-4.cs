    public static KeyValuePair<int, int> findenclosed(string text, string start, string end, int count, string[] notStart, string[]notEnd, bool mustnotspace = false)
    {
        string nexttext = text;
        int r = 0; 
        int p = 0; 
        int st = -1; 
        int en = -1; 
        for(int c = 0; c < count; c++) {
            p = 0;
            st = -1; 
            en = -1; 
            bool f = false; 
            bool lf = true;
            while ((!f || p > 0) && lf && nexttext != string.Empty)
            {
                if(notStart.Length > 0)
                {
                    int xt = 0;
                    foreach(string s1 in notStart)
                    {
                        string e1 = notEnd[xt];
                        int xc = 1;
                        while(nexttext.Contains(s1) && nexttext.Contains(e1))
                        {
                            KeyValuePair<int, int> en1 = findenclosed(nexttext, s1, e1, xc, new string[0], new string[0]);
                            int l = en1.Value - en1.Key + 1;
                            string kk = nexttext.Substring(en1.Value + 1);
                            nexttext = nexttext.Substring(0, en1.Key);
                            for(int kkf = 0; kkf < l; kkf++)
                            {
                                nexttext += (text == " " || end == " " || mustnotspace) ? "`": " ";
                            }
                            nexttext += kk;
                        }
                    }
                }
                int s = nexttext.IndexOf(start);
                int e = nexttext.IndexOf(end);
                if (s > -1 && !(start == end && f) && s <= e)
                {
                    p++;
                    if (!f) st = s + r;
                    f = true;
                    nexttext = nexttext.Remove(0, s + 1);
                    r += s + 1;
                } else {
                    if (e > -1)
                    {
                        p--;
                        en = e + r;
                        nexttext = nexttext.Remove(0, e + 1);
                        r += e + 1;
                    } else
                        lf = false;
                }
            }
        }
        return new KeyValuePair<int, int>(st, en);
    }
    public static string[] splitenclosed(string text, string separator, string[] start, string[] end, bool mustnotspace = false)
    {
        if(text == "")
            return new string[0] { };
        string[] ret = new string[0] { };
        string nexttext = text;
        int s = 0;
        int i = nexttext.IndexOf(separator);
        int r = 0;
        while(i > -1 && nexttext != string.Empty)
        {
            KeyValuePair<int, int> en = findenclosed(nexttext, start[0], end[0], 1, new string[0], new string[0], separator == " " || mustnotspace);
            int ix = 0;
            while (ix < start.Length)
            {
                while (en.Key > -1 && en.Value > -1)
                {
                    
                    string k = nexttext.Substring(0, en.Key);
                    nexttext = nexttext.Remove(0, en.Value + 1);
                    for (int f = 0; f < en.Value - en.Key + 1; f++)
                    {
                        k += (separator == " " || mustnotspace) ? "`" : " ";
                    }
                    nexttext = k + nexttext;
                    en = findenclosed(nexttext, start[ix], end[ix], 1, new string[0], new string[0], separator == " " || mustnotspace);
                }
                ix++;
                if (ix != start.Length)
                    en = findenclosed(nexttext, start[ix], end[ix], 1, new string[0], new string[0], separator == " " || mustnotspace);
            }
            if (nexttext == "")
                break;
            i = nexttext.IndexOf(separator);
            if(i < 0)
                break;
            Array.Resize(ref ret, ret.Length + 1);
            ret[ret.Length - 1] = text.Substring(s, (i + r) - s);
            s = i + r + 1;
            nexttext = nexttext.Remove(0, i + 1);
            r += i + 1;
            
            i = nexttext.IndexOf(separator);
        }
        Array.Resize(ref ret, ret.Length + 1);
        ret[ret.Length - 1] = text.Substring(s, text.Length - s);
        return ret;
    }
    public static string[] splitenclosed(string text, string separator, bool mustnotspace = false)
    {
        return splitenclosed(text, separator, new string[5] { "{", "[", "(", "<", new string(new char[1] {'"'})}, new string[5] { "}", "]", ")", ">", new string(new char[1] {'"'})}, mustnotspace);
    }
