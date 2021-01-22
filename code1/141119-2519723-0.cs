        ....
        // Start the program
        process.Start();
        while (!process.HasExited)
            Thread.Sleep( 500 );
        Process[] p = Process.GetProcessesByName( "testprogram" );
        if ( p.Length != 0 && p[0].Id == process.id && ! p[0].HasExited)
            throw new Exception("Oh oh");
