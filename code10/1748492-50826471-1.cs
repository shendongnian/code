    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void testMethod()
        {
            var scheduler = new Mock<Scheduler>();
            // you can now call .setup on the scheduler instance and use this mock.
            var sut = new SchedulerWrapper(scheduler.Object);
            ///var sut....sometests
        }
    }
    internal class SchedulerWrapper : Scheduler
    {
        private Scheduler _scheduler;
        public SchedulerWrapper(Scheduler scheduler)
        {
             _scheduler;
        }
        public overrride IScheduler CreateScheduler()
        {
             return _scheduler;
        }
    }
