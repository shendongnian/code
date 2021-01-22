    delegate long MyFuncDelegate(int N );
    
    MyFuncDelegate cpn = new MyFuncDelegate(MyFunc); 
    	
    IAsyncResult ar = cpn.BeginInvoke( 3, null, null ); 
    
    // Do some stuff 
    while( !ar.IsCompleted ) 
    { 
        // Do some stuff 
    } 
    	
    // we now know that the call is 
    // complete as IsCompleted has 
    // returned true 
    long answer = cpn.EndInvoke(ar); 
