    using System;
    using System.Threading;
    class Foo {
        public string Bar { get; private set; }
        public Foo(string bar) { Bar = bar; }
    }
    static class Program {
        static Foo foo = new Foo("abc");
        static void Main() {
            new Thread(() => {
                Register(ref foo);
            }).Start();
            for (int i = 0; i < 20; i++) {
                Mutate(ref foo);
                Thread.Sleep(100);
            }
            Console.ReadLine();
        }
        static void Mutate(ref Foo obj) {
            obj = new Foo(obj.Bar + ".");
        }
        static void Register(ref Foo obj) {
            while (obj.Bar.Length < 10) {
                Console.WriteLine(obj.Bar);
                Thread.Sleep(100);
            }
        }
    }
