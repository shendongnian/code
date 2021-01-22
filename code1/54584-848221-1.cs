    namespace stackOverflow
    {
    class Program
    {
        static void Main(string[] args)
        {
            IMyWorker worker = new MyWorker();
            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
        }
        static void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
      }
    }
