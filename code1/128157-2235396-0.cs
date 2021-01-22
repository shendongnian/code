    using System;
    using System.Globalization;
    using System.Threading;
    class Program {
        static void thread_test() {
            Console.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
        }
        public static void Main(params string[] args) {
            Thread t = new Thread(thread_test);
            t.CurrentCulture = new CultureInfo("it-it");
            t.Start();
            t.Join();
        }
    }
