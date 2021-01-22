    class MyClassApp
    {
       static void Main() 
       {
          CheckPrimeDelegate ckPrimDel = new CheckPrimeDelegate(Prime.Check);
          
          // Initiate the operation
          ckPrimDel.BeginInvoke(4501232117, new AsyncCallback(OnChkPrimeDone), null);
          
          // go do something else . . . .      
       }
    
       static void OnChkPrimeDone( IAsyncResult iAr)
       {
    	    AsyncResult ar = iAr as AsynchResult;
             CheckPrimeDelegate ckPrimDel = ar.AsyncDelegate as CheckPrimeDelegate;
             bool isPrime = ckPrimDel.EndInvoke(ar);
             Console.WriteLine(" Number is " + (isPrime? "prime ": "not prime");
       }
    }
