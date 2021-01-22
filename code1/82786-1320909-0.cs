    void Method()
    {
        stmt1;
        stmt2;
        
        new System.Threading.Timer(
            o =>   // timer callback
            {
                stmt3;
            },
            15000, // Delay
            0      // Repeat-interval; 0 for no repeat
        );
    }
