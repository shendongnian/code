    using System.Collections.Generic;
    using System.Linq;
    using System;
    interface IFoo { }
    class Foo : IFoo { //  A implements an interface I
        readonly int value;
        public Foo(int value) { this.value = value; }
        public override string ToString() { return value.ToString(); }
    }
    static class Program {
        static void Main() {
            // I have an undefined number of arrays of objects of type T
            IEnumerable<Foo[]> source=GetUndefinedNumberOfArraysOfObjectsOfTypeT();
            // I need an array of I at the end that is the sum of
            // all values from all the arrays. 
            IFoo[] arr = source.SelectMany(x => x).Cast<IFoo>().ToArray();
            foreach (IFoo foo in arr) {
                Console.WriteLine(foo);
            }
        }
        static IEnumerable<Foo[]> GetUndefinedNumberOfArraysOfObjectsOfTypeT() {
            yield return new[] { new Foo(1), new Foo(2), new Foo(3) };
            yield return new[] { new Foo(4), new Foo(5) };
        }
    }
