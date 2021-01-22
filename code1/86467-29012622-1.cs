    using System;
    class Solution
    {
        public int solution(string S)
        {
            int x1 = 0;
            int x2 = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == ')')
                    if (x1 <= 0) return 0;
                    else x1--;
                else if (S[i] == '(')
                    x1++;
            }
            if (x1 == 0)
                return 1;
            else
                return 0;
        }
    }
