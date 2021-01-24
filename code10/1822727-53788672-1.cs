    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace LongProcessDemo
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void StartProcess_OnClick(object sender, RoutedEventArgs e)
            {
                var longRunningTask = SimulateLongRunningTask();
                var spinner = ShowSpinner(longRunningTask);
                var tasks = new List<Task>
                {
                    longRunningTask,
                    spinner,
                };
                await Task.WhenAll(tasks);
            }
    
            private async Task ShowSpinner(Task longRunningTask)
            {
                var numDots = 0;
                while (!longRunningTask.IsCompleted)
                {
                    numDots++;
                    if (numDots > 3) numDots = 0;
                    LoadingText.Text = $"Waiting{new string('.', numDots)}";
                    await Task.Delay(TimeSpan.FromSeconds(.5));
                }
    
                LoadingText.Text = "Done!";
            }
    
            private async Task SimulateLongRunningTask()
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
