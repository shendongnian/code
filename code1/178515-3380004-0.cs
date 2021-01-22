    [TestMethod]
    public void Can_Start_And_End_Game()
    {
        try
        {
            Tetris tetris = new Tetris();
            tetris.Start();
            tetris.End();
        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception thrown: " + ex.ToString());
        }
    }
