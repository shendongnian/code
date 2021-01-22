    class MyController {
      public ActionResult Action1() {
        // Pull stuff out of ViewData
        
        DoStuff1(param1, param2, ...);
      }
    
      public ActionResult Action2() {
        DoStuff2(param1, param2, ...);
      }
      public void DoStuff1(/* parameters */) {
        // Do stuff 1
      }
      public void DoStuff2(/* parameters */) {
        // Do stuff 2
      }
    }
