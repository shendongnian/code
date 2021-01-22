    static void Brackets(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Brackets("", 0, 0, i);
            }
        }
        static void Brackets(string output, int open, int close, int pairs)
        {
            if((open==pairs)&&(close==pairs))
            {
                Debug.WriteLine(output);
            }
            else if ((open > pairs) || (close > pairs))
            {
                return;
            }
            else
            {
                if(open<pairs)
                    Brackets(output + "(", open+1, close, pairs);
                if(close<open)
                    Brackets(output + ")", open, close+1, pairs);
            }
        }
