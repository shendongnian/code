    Timer x = new Timer(state => CheckEffectExpiry(1), null, 5000 /* When to start*/, 300000 /* when to retry */);
>
     public void CheckEffectExpiry(object objectInfo)
            {
    
                //I hate C#'s way of accessing variables and such .
                //So I am doing this...
                Console.Write(DateTime.Now + " I was hit\n");
                if (lockf == 1)
                {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(DateTime.Now + " Starting Scan.....\n");
                Console.ForegroundColor = ConsoleColor.White;
             
                    lockf = 0;
                    Searcher.CcnDirSearch(ScanDir);
                    lockf = 1;
                
    
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(DateTime.Now + " Finished Scan.....\n");
                Console.ForegroundColor = ConsoleColor.White;
                }
    
            }
