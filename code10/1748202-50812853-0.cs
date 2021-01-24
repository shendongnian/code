    public partial class WaitingForm<T> : Form
    {
        // ...
        Task<T> task;
        public Task<T> Task
        {
            get => task;
            set
            {
                task = value.ContinueWith((task) =>
                {
                    Invoke((MethodInvoker)delegate () { Close(); });
                    return task.Result;
                });
            }
        }
    }
