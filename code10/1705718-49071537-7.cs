    using System;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static async Task<T> WaitForActionCompletionOrTimeout<T>(Func<T> action, int timeOut)
            {
                var result = default(T);
    
                var cancellationTokenSource = new CancellationTokenSource();
    
                Task timeoutTask = null;
                Task actionTask = null;
                var mre = new ManualResetEvent(false);
    
                try
                {
                    timeoutTask = Task.Delay(timeOut, cancellationTokenSource.Token);
    
                    actionTask = Task.Factory.StartNew(() =>
                    {
                        result = action.Invoke();
                    }, cancellationTokenSource.Token);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
                finally
                {
                    await Task.WhenAny(actionTask, timeoutTask).ContinueWith(t =>
                    {
                        cancellationTokenSource.Cancel();
                        mre.Set();
                    });
                }
    
                mre.WaitOne();
                return result;
            }
    
            private static PingReply actualPing(string hostname, int timeout)
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
                var a = new Thread(() => reply =  actualPing(hostname, timeout));
                a.Start();
                a.Join(timeout);
                return reply;
            }
    
            static void Main(string[] args)
            {
                var stopWatch = Stopwatch.StartNew();
                var expectedFail = WaitForActionCompletionOrTimeout(() => new Ping().Send("bogusdjfkhkjh", 200), 200).Result;
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} {expectedFail != null}");
                stopWatch = Stopwatch.StartNew();
                var expectedSuccess = WaitForActionCompletionOrTimeout(() => new Ping().Send("127.0.0.1", 200), 200).Result;
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} {expectedSuccess != null}");
    
                stopWatch = Stopwatch.StartNew();
                expectedFail = ForcePingTimeoutWithThreads("bogusdjfkhkjh", 200);
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} {expectedFail != null}");
                stopWatch = Stopwatch.StartNew();
                expectedSuccess = ForcePingTimeoutWithThreads("127.0.0.1", 200);
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} {expectedSuccess != null}");
    
                Console.ReadKey(false);
            }
        }
    }
