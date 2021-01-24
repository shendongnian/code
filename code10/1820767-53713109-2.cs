    long totalTiles = ((((rightBottom.X) - (topLeft.X)) + 1) * (((rightBottom.Y) - (topLeft.Y)) + 1));
    long currentTileProccessed = 0;
    Queue<long> taskTimes = new Queue<long>();
    int taskTimeHistoryLimit = 100;
    long taskTotal = (rightBottom.X - topLeft.X) * (rightBottom.Y - topLeft.Y);
    Stopwatch watch = new Stopwatch();
    long index = 0;
    for (long x = (topLeft.X); x <= (rightBottom.X); x++)
    {
        for (long y = (topLeft.Y); y <= (rightBottom.Y); y++)
        {
            index++;
            watch.Start();
            //Real job done here//
            watch.Stop();
            taskTimes.Enqueue(watch.ElapsedTicks);
            watch.Reset();
            while (taskTimes.Count > taskTimeHistoryLimit)
            {
                taskTimes.Dequeue();
            }
            TimeSpan timeRemaining = new TimeSpan((taskTotal - index) * (long)taskTimes.Average());
            this.Dispatcher.Invoke((Action)delegate () {
                EstimatedTimeLeft_TextBlock.Text = "Days : " + timeRemaining.Days.ToString("D2") + ", Hours : " + timeRemaining.Hours.ToString("D2") + ", Minutes :" + timeRemaining.Minutes.ToString("D2") + ", Seconds :" + timeRemaining.Seconds.ToString("D2");
            });
        }
    }
