    [TestFixture]
    public class DeadlockTests
    {
        [Test]
        public void TestForDeadlock()
        {
            Thread thread = new Thread(ThreadFunction);
            thread.Start();
            if (!thread.Join(5000))
            {
                Assert.Fail("Deadlock detected");
            }
        }
        private void ThreadFunction()
        {
            // do something that causes a deadlock here
            Thread.Sleep(10000);
        }
    }
