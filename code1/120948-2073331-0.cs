    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Reflection.Emit;
    public interface ISomeInterface {
        void SetSomeBool(bool value);
    }
    class SomeBase : ISomeInterface {
        public virtual bool SomeBool { get; set; }
        void ISomeInterface.SetSomeBool(bool value) { SomeBool = value; }
    }
    class SomeDerived : SomeBase {
        // ... extends SomeBase
    }
    static class Program {
        static void Main() {
            var item1 = new SomeBase();
            var item2 = new SomeDerived();
            var items = new List<ISomeInterface> { item1, item2};
            ISomeInterface group = GroupGenerator.Create(items);
            group.SetSomeBool(true);
            Console.WriteLine(item1.SomeBool); // true
            Console.WriteLine(item2.SomeBool); // true
            group.SetSomeBool(false);
            Console.WriteLine(item1.SomeBool); // false
            Console.WriteLine(item2.SomeBool); // false
        }
    }
