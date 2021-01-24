    private static BoardScript _uniqueBoardScript;
     private BoardScript()
     {}
     public static BoardScript GetInstance()
     {
         if(_uniqueBoardScript==null)
         { 
             _uniqueBoardScript = new BoardScript();
         }
         return _uniqueBoardScript;
     }
