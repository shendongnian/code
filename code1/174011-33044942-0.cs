    class Program
    {
        static void Main()
        {
            Task.Factory.StartNew(
                () =>
                    {
                        throw new Exception();
                    })
                .Success(() => Console.WriteLine("Works"))
                .Fail((ex) => Console.WriteLine("Fails")).Wait();
            Console.ReadKey();
        }
    }
    public static class TaskExtensions
    {
        public static Task Success(this Task task, Action onSuccess)
        {
            task.ContinueWith((t) =>
            {
                if (!t.IsFaulted)
                {
                    onSuccess();
                }
            });
            return task;
        }
        public static Task Fail(this Task task, Action<Exception> onFail)
        {
            return task.ContinueWith(
                (t) =>
                {
                    if (t.IsFaulted)
                    {
                        t.Exception.Handle(x => true);
                        onFail(t.Exception.Flatten());
                    }
                });
        }
    }
