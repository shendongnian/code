    class myclass
    {
         bool myFuncWasCalled;
    
         public void myfunc()
         {
              myFuncWasCalled=true;
              // do some actions
         }
         public void anotherfunc()
         {
              if(myFuncWasCalled)
                    // do some action ;
         }
       
    }
