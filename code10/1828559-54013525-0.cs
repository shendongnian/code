    public class ViewModel
    {
        public INotifyTaskCompletion<string> Name { get; set; }
        public ViewModel()
        {
            Name = NotifyTaskCompletetion.Complete(GetNameAsync());
        }
        private async Task<string> GetNameAsync()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(5000);
                return "Foo";
            });
        }
    }
