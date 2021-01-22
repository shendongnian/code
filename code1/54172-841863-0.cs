    public class foo {    
      IEnumerable<string> AllThreads;    
      
      private void getThread() {
         AllThreads = (from sc in db.ScreenCycles
                          join s in db.Screens on sc.ScreenID equals s.ScreenID
                          select s.Screen1 + " " + sc.Thread);
      }
    }
