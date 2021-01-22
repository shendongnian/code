    void Method()
    {
        Statement1();
        Statement2();
    
        // Start the timer for a single 15 second shot.
        // Keep a reference to it (Mytimer) so that the timer doesn't get collected as garbage
        Mytimer = new System.Threading.Timer((a) =>
            {
                // Invoke the 3rd statement on the GUI thread
    	        BeginInvoke(new Action(()=>{ Statement3(); }));
            }, 
    	null,
    	15000, // 15 seconds
    	System.Threading.Timeout.Infinite); // No repeat
    }
