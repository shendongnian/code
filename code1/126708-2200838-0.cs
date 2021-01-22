    public partial class Window1 : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        public Window1()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ReportsProgress = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(update_progress);
        }
    
        void worker_DoWork(object sender, DoWorkEventArgs e){
            DoSomeLongTask();
            //call worker.ReportProgress to update bar
        }
        void update_progress(object sender, ProgressChangedEventArgs e)
        {
            myscrollbar.Value = e.Value;
        }
    }
