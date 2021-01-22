    public class ThreadWithState
    {
        private string message;
        public ThreadWithState(string message)
        {
            this.message = message;
        }
        public void Work()
        {
            Console.WriteLine($"I, the thread write: {this.message}");
        }
    }
