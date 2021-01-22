    bool pause = true;
    
           void async foo()
            {
            //some code
            
                while (pause)
                 {
                 await Task.Delay(100);
                 }
        
            //some code
            }
