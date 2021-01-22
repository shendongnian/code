    public static int mystrcmp(string st1, string st2)
    {
        int iST1 = 0, iST2=0;
        for (int i = 0; i < (st1.Length > st2.Length ? st1.Length : st2.Length); i++)
        {
            iST1 += (i >= st1.Length ? 0 : st1[i]) - (i >= st2.Length ? 0 : st2[i]);
            if (iST2 < 0)
            {
                if (iST1 < 0)
                    iST2 += iST1;
                if (iST1 > 0)
                    iST2 += -iST1;
            }
            else
            {
                iST2 += iST1;
            }
        }
        return iST2;
    }
