    [TestMethod]
    public void Test_Contructor()
    {
        Tetris tetris = new Tetris();
        // make assertions
    }
    
    [TestMethod]
    public void Test_Start()
    {
        // setup
        Tetris tetris = new Tetris();
        
        // exercise
        tetris.Start();
    
        // make assertions
    }
    
    [TestMethod]
    public void Test_End()
    {
        // setup
        Tetris tetris = new Tetris();
        tetris.Start();
    
        // exercise
        tetris.End();
    
        // make assertions
    }
