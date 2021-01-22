    abstract class IDObject<T> : IComparable<T> where T : IDObject<T> {
        public int ID { get; set; }
        public int CompareTo(T other) {
            return ID.CompareTo(other.ID);
        }
    }
    class Foo : IDObject<Foo> {}
    class Bar : IDObject<Bar> {}
    static class Program {
       static void Main() {
           var foo1 = new Foo { ID = 1 };
           var foo2 = new Foo { ID = 2 };
           var bar1 = new Bar { ID = 1 };
           var bar2 = new Bar { ID = 2 };
           Console.WriteLine(foo1.CompareTo(foo2));
           Console.WriteLine(bar2.CompareTo(bar1));
           //error CS1503: Argument '1': cannot convert from 'Bar' to 'Foo'
           //Console.WriteLine(foo1.CompareTo(bar1));
       }
    }
