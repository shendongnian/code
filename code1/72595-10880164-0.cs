    using System;
    using System.Runtime.CompilerServices;
    namespace GCCollectNotification
    {
        class ObjectToWatch { }
        class Notifier
        {
            public object ObjectToWatch { get; set; }
            ~Notifier() { Console.WriteLine("object is collected"); }
        }
        class Program
        {
            private ConditionalWeakTable<object, Notifier> map
                = new ConditionalWeakTable<object, Notifier>();
            public void Test()
            {
                var obj = new ObjectToWatch();
                var notifier = map.GetOrCreateValue(obj);
                notifier.ObjectToWatch = obj;
            }
            static void Main(string[] args)
            {
                new Program().Test();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                // "object is collected" should have been printed by now
                Console.WriteLine("end of program");
            }
        }
    }
