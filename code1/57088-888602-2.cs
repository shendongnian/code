    let demoPercentDone() =
        for i in 0..100 do
            System.Console.Write( "\rProcessing {0}%...", i )
            System.Threading.Thread.Sleep( 1000 )
        done
        System.Console.WriteLine()
    
    demoPercentDone()
