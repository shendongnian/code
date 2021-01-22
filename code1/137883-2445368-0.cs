    [TestFixture]
    public class BGWorkerTest
    {
        string output1;
        string output2;
        [Test]
        public void DoTest()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (sender, args) =>
                                       {
                                           output1 = DoThing1();
                                           output2 = DoThing2();
                                       };
            backgroundWorker.RunWorkerAsync();
            //Wait for BG to finish
            Thread.Sleep(3000);
            Assert.AreEqual("Thing1",output1);
            Assert.AreEqual("Thing2",output2);
        }
        public string DoThing1()
        {
            Thread.Sleep(1000);
            return "Thing1";
        }
        public string DoThing2()
        {
            Thread.Sleep(1000);
            return "Thing2";
        }
    }
