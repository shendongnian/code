    void demoPercentDone() {
        for(int i = 0, i < 100, i++){
            System.Console.Write( sprintf "\rProcessing (%i)%%..." i )
            System.Threading.Thread.Sleep( 1000 )
        }
        System.Console.WriteLine()
    
    }
