    namespace ConsoleApplication1
    {
        class Program
        {
            private static WaitHandle[] waitHandles;
            private static event EventHandler Evt1;
            private static event EventHandler Evt2;
    
            static void Main(string[] args)
            {
                waitHandles = new WaitHandle[]{
                     new ManualResetEvent(false),
                     new ManualResetEvent(false)
                };
    
                Evt1 += new EventHandler(Program_Evt1);
                Evt2 += new EventHandler(Program_Evt2);
    
                OnEvt1();
                OnEvt2();
    
                WaitHandle.WaitAll(waitHandles);
    
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
    
            static void Program_Evt2(object sender, EventArgs e)
            {
                Thread.Sleep(2000);
                ((ManualResetEvent)waitHandles[0]).Set();
            }
    
            static void Program_Evt1(object sender, EventArgs e)
            {
                ((ManualResetEvent)waitHandles[1]).Set();
            }
    
            static void OnEvt1()
            {
                if (Evt1 != null)
                    Evt1(null, EventArgs.Empty);
            }
    
            static void OnEvt2()
            {
                if (Evt2 != null)
                    Evt2(null, EventArgs.Empty);
            }
    
    
        }
    }
