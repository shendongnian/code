    class App : Form
    {
        Mutex mutex;
        App()
        {
            Text = "Single Instance!";
            mutex = new Mutex(false, "SINGLE_INSTANCE_MUTEX");
            if (!mutex.WaitOne(0, false)) 
            {
                mutex.Close();
                mutex = null;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                mutex.ReleaseMutex();
            base.Dispose(disposing);
        }
        static void Main()
        {
            App app = new App();
            if (app.mutex != null) Application.Run(app);
            else MessageBox.Show("Instance already running");
        }
    }
