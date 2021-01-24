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
    
            static void Main(string[] args)
            {
                var stopWatch = Stopwatch.StartNew();
                var expectedFail = WaitForActionCompletionOrTimeout(() => new Ping().Send("bogusdjfkhkjh", 200), 200).Result;
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} {expectedFail != null}");
                stopWatch = Stopwatch.StartNew();
                var expectedSuccess = WaitForActionCompletionOrTimeout(() => new Ping().Send("127.0.0.1", 200), 200).Result;
                Console.WriteLine($"{stopWatch.Elapsed.TotalMilliseconds} {expectedSuccess != null}");
                
                Console.ReadKey(false);
            }
        }
    }
