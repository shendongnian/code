    public void functionA(ref bool cond)
            {
                cond = specificCondition;
                if (!specificCondition)
                {
                    return;
                }
            }
    
            public void functionB()
            {
                bool cond = false;
                functionA(ref cond);
    
                if (cond)
                {
                    functionC();
                }
            }
    
            public void functionC()
            {
                Console.WriteLine("OK");
            }
