    public class ViewModelTests
    {
        [Fact]
        public void Test()
        {
            string observed = "";
            new TestScheduler().With(scheduler =>
            {
                var observable = scheduler.CreateColdObservable(
                    scheduler.OnNextAt(100, "Done"));
                observable.Subscribe(value => observed = value);
                Assert.Equal("", observed);
                scheduler.AdvanceByMs(99);
                Assert.Equal("", observed);
                scheduler.AdvanceByMs(1);
                Assert.Equal("Done", observed);
            });
        }
    }
