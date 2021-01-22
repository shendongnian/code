    private void button1_Click(object sender, EventArgs e)
    {
        ProcessAsync("beer", 1);
    }
    protected virtual void ProcessAsync(object data, int count)
    {
        var worker = new BackgroundWorker();
        worker.DoWork += (sender, e) =>
        {
            throw new InvalidOperationException("oh shiznit!");
        };
        worker.RunWorkerCompleted += (sender, e) =>
        {
            //If an error occurs we need to tell the data about it
            if (e.Error != null)
            {
                count++;
                //System.Threading.Thread.Sleep(count * 5000);
                if (count <= 10)
                {
                    if (count % 5 == 0)
                        this.Logger.Fatal("LOAD ERROR - The system can't load any data - " + count.ToString(), e.Error);
                    else
                        this.Logger.Error("LOAD ERROR - The system can't load any data - " + count.ToString(), e.Error);
                    this.ProcessAsync(data, count);
                }
            }
        };
        worker.RunWorkerAsync();
    }
    SomeLogger Logger = new SomeLogger();
    class SomeLogger
    {
        public void Fatal(string s, Exception e)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
        public void Error(string s, Exception e)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
    }
