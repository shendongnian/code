    //Assuming the thread name given is 'newthread'   
    //First Start a thread     
        
    newthread.Start();   
      
    //use Console Key Class to read a key from keyboard    
    ConsoleKeyInfo cki = new ConsoleKeyInfo();  
    cki = Console.ReadKey(true);
    
    //I am using letter 'p' to pause    
    if (cki.Key == ConsoleKey.P)   
    {  
      newthread.Suspend();  
      Console.WriteLine("Process Is Paused,Press 'Enter' to Continue...");  
    }  
    
    //Thread Resumption can only occur through another thread   
    //If the thread control has passed on to the main function    
    //resume it from there    
    
    
    // Resuming Thread if paused   
    if (newthread.ThreadState>0)    
    {    
      ConsoleKeyInfo ckm = new ConsoleKeyInfo();   
      ckm = Console.ReadKey(true);    
      if (ckm.Key == ConsoleKey.Enter)    
       {    
         Console.WriteLine("Resuming Process...");    
         newthread.Resume();    
       }       
    }  
