                int rw = 967;
                int tenPercent = rw / 10;
                int percentCounter = 0;
                for (int rCnt = 1; rCnt <= rw; rCnt++)
                {
                    
                    if( ++percentCounter == tenPercent )
                    {
                        double progress = rCnt / (double)rw;
                        Console.WriteLine("Progress : {0}", progress);
                        percentCounter = 0;
                    }
                }
                Console.ReadLine();
