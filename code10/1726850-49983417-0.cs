    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Thread0
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
            private static readonly Random _random = new Random();
            private List<int> lst = new List<int>();
            private bool isRun = false;
    
            private void startButton_Click(object sender, EventArgs e)
            {
                isRun = true;
                stopButton.Enabled = true;
                startButton.Enabled = false;
                var tskMain = Task.Run(() =>
                {
                    for (int i = 0; i < 8; i++)
                    {
                        var tsk1 = Task.Run(() =>
                        {
                            while (true)
                            {
                                int max = 0;
                                int min = Int32.MaxValue;
                                lock (lst)
                                {
                                    int num = _random.Next(1, 1000000);
                                    lst.Add(num);
                                    foreach (var x in lst)
                                    {
                                        if (x > max) max = x;
                                        if (min > x) min = x;
                                    }
                                    listListView.BeginInvoke(new Action(() => listListView.Items.Insert(0, num.ToString())));
                                }
                                maxTextBox.BeginInvoke(new Action(() => maxTextBox.Text = max.ToString()));
                                minTextBox.BeginInvoke(new Action(() => minTextBox.Text = min.ToString()));
    
                                if (!isRun) break;
    
                                Thread.Sleep(100);
                            }
                        });
                    }
                });
            }
    
            private void stopButton_Click(object sender, EventArgs e)
            {
                isRun = false;
                stopButton.Enabled = false;
                startButton.Enabled = true;
            }
        }
    }
