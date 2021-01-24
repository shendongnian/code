    public class MyViewModel : ReactiveObject
    {
        public string Observed { get; set; }
    
        public MyViewModel()
        {
            Observed = "";
    
            this.MyCommand = ReactiveCommand
                .CreateFromTask(SomeAsyncMethod);
        }
    
        public ReactiveCommand<Unit, Unit> MyCommand { get; }
    
        private async Task SomeAsyncMethod()
        {
            await RxApp.TaskpoolScheduler.Sleep(TimeSpan.FromMilliseconds(100));
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
                var vm = new MyViewModel();
    
                vm.MyCommand.Execute().Subscribe();
                Assert.Equal("", vm.Observed);
    
                scheduler.AdvanceByMs(99);
                Assert.Equal("", vm.Observed);
    
                scheduler.AdvanceByMs(1);
                Assert.Equal("Done", vm.Observed);
            });
        }
    }
