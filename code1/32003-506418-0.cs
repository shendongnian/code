    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    static class Program
    {
        static void Main()
        {
            // setup some form state
            Form form = new Form();
            ListView list = new ListView();
            list.View = View.List;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            form.Controls.Add(list);
            list.Dock = DockStyle.Fill;
            // start the worker when the form loads
            form.Load += delegate {
                worker.RunWorkerAsync();
            };
            worker.DoWork += delegate
            {
                // this code happens on a background thread, so doesn't
                // block the UI while running - but shouldn't talk
                // directly to any controls
                for(int i = 0 ; i < 500 ; i++) {
                    worker.ReportProgress(0, "Item " + i);
                    Thread.Sleep(150);
                }
            };
            worker.ProgressChanged += delegate(object sender,
               ProgressChangedEventArgs args)
            {
                // this is invoked on the UI thread when we
                // call "ReportProgress" - allowing us to talk
                // to controls; we've passed the new info in
                // args.UserState
                list.Items.Add((string)args.UserState);
            };
            Application.Run(form);
        }
    }
