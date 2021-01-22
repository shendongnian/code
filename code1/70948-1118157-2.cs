     public static int mystrcmp(string st1, string st2)
     {
         int iST1 = 0, iST2 = 0;
         for (int i = 0; i < (st1.Length > st2.Length ? st1.Length : st2.Length); i++)
         {
             if (i < st1.Length)
                 iST1 += st1[i] + i;
             if (i < st2.Length)
                 iST2 += st2[i] + i;                
         }
         return iST1 - iST2;
     }
