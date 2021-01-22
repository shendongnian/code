            public void YourFunction()
            {
                if(AtLeast2AreTrue(b1, b2, b3, b4, b5))
                {
                    // do stuff
                }
            }
    
            private bool AtLeast2AreTrue(params bool[] values)
            {
                int trueCount = 0;
                for(int index = 0; index < values.Length || trueCount >= 2; index++)
                {
                    if(values[index])
                        trueCount++;
                }
    
                return trueCount > 2;
    
            }
