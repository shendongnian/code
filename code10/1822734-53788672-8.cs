    public static class TaskExtensions
    {
        public static async Task WithSpinner(this Task longRunningTask, TextBlock spinnerTextBox)
        {
            async Task ShowSpinner()
            {
                var numDots = 0;
                while (!longRunningTask.IsCompleted)
                {
                    if (numDots++ > 3) numDots = 0;
                    spinnerTextBox.Text = $"Waiting{new string('.', numDots)}";
                    await Task.Delay(TimeSpan.FromSeconds(.5));
                }
                spinnerTextBox.Text = "Done!";
            }
            var spinner = ShowSpinner();
            var tasks = new List<Task>
            {
                longRunningTask,
                spinner,
            };
            await Task.WhenAll(tasks);
        }
    }
