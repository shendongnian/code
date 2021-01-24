    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace TaskAndTimer
    {
        public partial class MainForm : Form
        {
            private int[] taskConfigs = { 1200, 1300, 1100, 800 };
            private Queue<int> queue;
            public MainForm()
            {
                InitializeComponent();
            }
            private async void btnStart_Click(object sender, EventArgs e)
            {
                queue = new Queue<int>(taskConfigs);
                Task<int> firstTask;
                Task<int>[] tasks = new Task<int>[] { };
                int result = -1;
                progressBar.Style = ProgressBarStyle.Marquee;
                do
                {
                    log.AppendText($"Next round...{Environment.NewLine}");
                    log.AppendText($"-------------{Environment.NewLine}");
                    tasks =
                        tasks
                            .Concat(new[] { GetWaitTask(), CreateNextTask() })
                            .ToArray();
                    LogTasks("Current tasks:", tasks);
                    firstTask = await Task.WhenAny(tasks);
                    LogTasks("First task:", firstTask);
                    tasks = tasks.Except(new[] { firstTask }).ToArray();
                    LogTasks("Remaining tasks:", tasks);
                    result = await firstTask;
                    log.AppendText($"-------------{Environment.NewLine}");
                    log.AppendText(Environment.NewLine);
                }
                while (result == -1 && queue.Any());
                log.AppendText($"result = [{result}]\r\n");
                progressBar.Style = ProgressBarStyle.Blocks;
            }
            private Task<int> GetWaitTask()
            {
                return Task.Run(async () => { await Task.Delay(1000); return -1; });
            }
            private Task<int> CreateNextTask()
            {
                if (queue.Any())
                {
                    int data = queue.Dequeue();
                    return Task.Run(async () => { await Task.Delay(data); return data; });
                }
                return Task.FromResult(-1);
            }
            private void LogTasks(string message, params Task<int>[] tasks)
            {
                log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
                log.AppendText($"> {message}");
                foreach (var task in tasks)
                {
                    log.AppendText($" [{task.Id}];");
                }
                log.AppendText(Environment.NewLine);
            }
        }
    }
