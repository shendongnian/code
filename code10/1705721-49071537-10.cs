    using System;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
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
                }).Wait();
                
                return result;
            }
    
            private static PingReply normalPing(string hostname, int timeout)
            {
                try
                {
                    return new Ping().Send(hostname, timeout);
                }
                catch
                {
                    return null;
                }
            }
    
            private static PingReply ForcePingTimeoutWithThreads(string hostname, int timeout)
            {
                PingReply reply = null;
                var a = new Thread(() => reply =  normalPing(hostname, timeout));
                a.Start();
                a.Join(timeout);
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
                catch
                {
                    return null;
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
