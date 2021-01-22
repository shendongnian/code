    public delegate void FinishedTasksHandler(string returnValue);
    public class MyController
    {
        private ISynchronizeInvoke _syn; 
        public MyController(ISynchronizeInvoke syn) {  _syn = syn; } 
        public event FinishedTasksHandler Finished; 
        public void SubmitTask(string someValue)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(state => submitTask(someValue));
        }
        private void submitTask(string someValue)
        {
            someValue = someValue + " " + DateTime.Now.ToString();
            System.Threading.Thread.Sleep(5000);
    //Finished(someValue); This causes cross threading error if called like this.
            if (Finished != null)
            {
                if (_syn.InvokeRequired)
                {
                    _syn.Invoke(Finished, new object[] { someValue });
                }
                else
                {
                    Finished(someValue);
                }
            }
        }
    }
