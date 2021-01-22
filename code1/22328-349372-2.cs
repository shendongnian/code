     [TestMethod]
     public void StartTest()
     {
          Process proc = new FakeProcess();  // May need to use a wrapper class
          UtilityManager manager = new UtilityManager( proc );
          manager.CommandLine = "command";
          ...
           
          manager.Start();
          
          Assert.IsTrue( proc.StartCalled );
          Assert.IsNotNull( proc.StartInfo );
          Assert.AreEqual( "command", proc.StartInfo.FileName );
          ...
     }
