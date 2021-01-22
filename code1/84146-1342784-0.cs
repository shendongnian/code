    using System;
    namespace test {
        class Outer {
            public interface IInner {
                void SayHello();
            }
            private class Inner : IInner {
                public void SayHello() {
                    Console.WriteLine("Hello");
                }
            }
            public IInner MakeInner() {
                return new Inner();
            }
        }
        class Program {
            static void Main(string[] args) {
                Outer x = new Outer();
                x.MakeInner().SayHello();
            }
        }
    }
