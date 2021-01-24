    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                const int TotalTimeMS = 200;
                const int DelayMS = 10;
                TimeLoop(() =>
                {
                    Console.WriteLine($"First {DateTime.Now.Ticks}");
                }, TotalTimeMS, DelayMS);
    
                await TimeLoopAsync(() =>
                {
                    Console.WriteLine($"Second {DateTime.Now.Ticks}");
                }, TotalTimeMS, DelayMS);
    
                Console.WriteLine("Done");
                Console.ReadKey();
            }
    
            public static void TimeLoop(Action action, int totalTime, int delay)
            {
                var futureTime = DateTime.Now.AddMilliseconds(totalTime);
                while (futureTime > DateTime.Now)
                {
                    action.Invoke();
                    Thread.Sleep(delay);                
                }
            }
    
            public static async Task TimeLoopAsync(Action action, int totalTime, int delay)
            {
                var futureTime = DateTime.Now.AddMilliseconds(totalTime);
                while (futureTime > DateTime.Now)
                {
                    action.Invoke();
                    await Task.Delay(delay);
                }
            }
        }
    }
    //OUTPUTS
    //First 636813466330097482
    //First 636813466330207562
    //First 636813466330317509
    //First 636813466330427504
    //First 636813466330537519
    //First 636813466330647498
    //First 636813466330757504
    //First 636813466330867485
    //First 636813466330977501
    //First 636813466331087479
    //First 636813466331197483
    //First 636813466331307522
    //First 636813466331417580
    //First 636813466331527516
    //First 636813466331637533
    //First 636813466331747513
    //Second 636813466331867481
    //Second 636813466332197479
    //Second 636813466332317508
    //Second 636813466332427498
    //Second 636813466332647472
    //Second 636813466332757495
    //Second 636813466332977526
    //Second 636813466333087469
    //Second 636813466333197468
    //Second 636813466333417483
    //Second 636813466333527481
    //Second 636813466333757457
    //Done
