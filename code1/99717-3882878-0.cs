                int tryCount = 0;
                while (tryCount < 3)
                {
                    try
                    {
                        someReturn = SomeFunction(someParams);
                    }
                    catch (Exception)
                    {
                        tryCount++; 
                        continue;
                    }
                    break; 
                }
