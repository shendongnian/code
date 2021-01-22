    public static int DokleSuIsti(IList<string> prevzemNow, IList<string> prevzemOld)
            {
                int dobroja = 0;
                int kolikohinaje;
                if (prevzemOld.Count() < prevzemNow.Count())
                {
                    kolikohinaje = prevzemOld.Count();
                }
                else
                {
                    kolikohinaje = prevzemNow.Count();
                }
    
    
    
                for (int i = 0; i < kolikohinaje; i++)
                {
                    if (!Object.Equals(prevzemNow[i], prevzemOld[i]))
                    {
                        dobroja = i;
                        return dobroja;
                    }
                    dobroja = i;
                }
                return dobroja;
            }
