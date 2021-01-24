    public class MyViewModel : ReactiveObject
    {
        private readonly IScheduler _taskpoolScheduler;
        public string Observed { get; set; }
    
        public MyViewModel(IScheduler scheduler)
        {
            _taskpoolScheduler = scheduler;
            Observed = "";
    
            this.MyCommand = ReactiveCommand
                .CreateFromTask(SomeAsyncMethod);
        }
    
        public ReactiveCommand<Unit, Unit> MyCommand { get; }
    
        private async Task SomeAsyncMethod()
        {
            await _taskpoolScheduler.Sleep(TimeSpan.FromMilliseconds(100));
            Observed = "Done";
        }
    }
    
    public class ViewModelTests
    {
        [Fact]
        public void Test()
        {
            new TestScheduler().With(scheduler =>
            {
                var vm = new MyViewModel(scheduler); ;
    
                vm.MyCommand.Execute().Subscribe();
                Assert.Equal("", vm.Observed);
    
                scheduler.AdvanceByMs(99);
                Assert.Equal("", vm.Observed);
    
                scheduler.AdvanceByMs(0);
                Assert.Equal("Done", vm.Observed);
            });
        }
    }
