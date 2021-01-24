    public static void Main()
    {
        using (var cancellationTokenSource = new CancellationTokenSource())
        {
            Console.CancelKeyPress += (_, ccea) => {
                cancellationTokenSource.Cancel();
                ccea.Cancel = true; //cancel the cancel.  There's too many cancels!
            };
            while (!cancellationTokenSource.Token.WaitHandle.WaitOne(1000))
            {
                Console.WriteLine("Still running...");
            }
            Console.WriteLine("Cancellation is requested. Trying to dispose cancellation token...");
        }
        Console.WriteLine("Just before close");
    }
