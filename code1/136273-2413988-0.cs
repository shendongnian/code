    public void main() 
    { 
         executeFn("1"); 
         while(SomeBoolValueIndicatingIfAsyncIsDone == false) { Thread.Sleep(10); continue; }
         executeFn("2"); //this wll run after the first call is completed
    } 
     
    bool SomeBoolValueIndicatingIfAsyncIsDone = false;
    private bool executeFn(string someval) 
    { 
         SomeBoolValueIndicatingIfAsyncIsDone = false;
         runSomeAsyncCode(); //This is some async uploading function that is yet to be defined. 
         SomeBoolValueIndicatingIfAsyncIsDone = true;
    } 
