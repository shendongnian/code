    public abstract class Algorithm
    {
        private readonly AlgorithmContext _context;
        public Algorithm(AlgorithmContext context)
        {
            _context = context;
            _context.Terminated += (sender, e) =>
            {
                Terminate();
            };
        }
        public abstract void Terminate();
    }
    public class SmoothImage : Algorithm
    {
        public SmoothImage(AlgorithmContext context) : base(context)
        {
        }
        public override void Terminate()
        {
            // do whatever you want
        }
    }
    public class SharpenImage : Algorithm
    {
        public SharpenImage(AlgorithmContext context) : base(context)
        {
        }
        public override void Terminate()
        {
            // do whatever you want
        }
    }
    public class Example
    {
        public void Process(float[] imagedata)
        {
            var Task1 = Task.Run(() =>
            {
                using (var ctx = new AlgorithmContext("Context 1"))
                {
                    SmoothImage smoothImage = new SmoothImage(ctx);
                    SharpenImage sharpenImage = new SharpenImage(ctx);
                }
            });
            // ...
            Task.WaitAll(Task1, Task2, Task3);
        }
    }
    public class AlgorithmContext : IDisposable
    {
        public AlgorithmContext(string name)
        {
            Name = name;
        }
        public event EventHandler Terminated;
        public string Name { get; }
        public void Dispose()
        {
            Terminate();
        }
        public void Terminate()
        {
            Terminated?.Invoke(this, EventArgs.Empty);
        }
    }
