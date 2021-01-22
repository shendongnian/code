    static string InPlaceCharArray(string str)
    {
        var len = str.Length;
        var src = str.ToCharArray();
        int dstIdx = 0;
        bool lastWasWS = false;
        for (int i = 0; i < len; i++)
        {
            var ch = src[i];
            if (src[i] == '\u0020')
            {
                if (lastWasWS == false)
                {
                    src[dstIdx++] = ch;
                    lastWasWS = true;
                }
            }
            else
            { 
                lastWasWS = false;
                src[dstIdx++] = ch;
            }
        }
        return new string(src, 0, dstIdx);
    }
