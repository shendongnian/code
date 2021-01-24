    public static void functionA(out bool cond)
                {
    		bool specificCondition = true;
                    cond = specificCondition;
                    if (!specificCondition)
                    {
                        return;
                    }
                }
        
                public static void functionB()
                {
                    bool cond;
                    functionA(out cond);
        
                    if (cond)
                    {
                        functionC();
                    }
                }
        
                public static void functionC()
                {
                    Console.WriteLine("OK");
                }
