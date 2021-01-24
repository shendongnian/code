    using System;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            //this can easily be async Task<PingReply> or even made generic (original version was), but I wanted to be able to test all versions with the same code
            private static PingReply PingOrTimeout(string hostname, int timeOut)
            {
                PingReply result = null;
                var cancellationTokenSource = new CancellationTokenSource();
                var timeoutTask = Task.Delay(timeOut, cancellationTokenSource.Token);
    
                var actionTask = Task.Factory.StartNew(() =>
                {
                    result = normalPing(hostname, timeOut);
                }, cancellationTokenSource.Token);
    
                Task.WhenAny(actionTask, timeoutTask).ContinueWith(t =>
                {
                    cancellationTokenSource.Cancel();
                }).Wait(); //if async, remove the .Wait() and await instead!
                
                return result;
            }
    
            private static PingReply normalPing(string hostname, int timeout)
            {
                try
                {
                    return new Ping().Send(hostname, timeout);
                }
                catch //never do this kids, this is just a demo of a concept! Always log exceptions!
                {
                    return null; //or this, in such a low level method 99 cases out of 100, just let the exception bubble up
                }
            }
    
            private static PingReply ForcePingTimeoutWithThreads(string hostname, int timeout)
            {
                PingReply reply = null;
                var a = new Thread(() => reply =  normalPing(hostname, timeout));
                a.Start();
                a.Join(timeout); //or a.Abort() after a timeout... brrr I like to think that the ping might go on and be successful in life with .Join :)
                return reply;
            }
    
            static byte[] b = new byte[32];
            static PingOptions po = new PingOptions(32, true);
            static PingReply JimiPing(string hostname, int timeout)
            {
                try
                {
                    return new Ping().Send(hostname, timeout, b, po);
                }
                catch //never do this kids, this is just a demo of a concept! Always log exceptions!
                {
                    return null; //or this, in such a low level method 99 cases out of 100, just let the exception bubble up
                }
            }
    
            static void RunTests(Func<string, int, PingReply> timeOutPinger)
            {
                var stopWatch = Stopwatch.StartNew();
                var expectedFail = timeOutPinger("bogusdjfkhkjh", 200);
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} false={expectedFail != null}");
                stopWatch = Stopwatch.StartNew();
                var expectedSuccess = timeOutPinger("127.0.0.1", 200);
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} true={expectedSuccess != null && expectedSuccess.Status == IPStatus.Success}");
            }
    
            static void Main(string[] args)
            {
                RunTests(normalPing);
                RunTests(PingOrTimeout);
                RunTests(ForcePingTimeoutWithThreads);
                RunTests(JimiPing);
                
                Console.ReadKey(false);
            }
        }
    }
