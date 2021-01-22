    using System;
    
    namespace Examples
    {
    
        public class Continue : Exception { }
        public class Break : Exception { }
    
        public class NestedLoop
        {
            static public void ContinueOnParentLoopLevel()
            {
                while(true)
                try {
                   // outer loop
    
                   while(true)
                   {
                       // inner loop
    
                       try
                       {
                           throw new Exception("Bali mu mamata");
                       }
                       catch (Exception)
                       {
                           // how do I continue on the outer loop from here?
    
                           throw new Continue();
                       }
                   }
                } catch (Continue) {
                       continue;
                }
            } 
        }
    
    }
    
    }
