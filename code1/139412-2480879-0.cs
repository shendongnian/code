    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace SO_2480770 {
        interface IFoo {}
        class MyBase : IFoo {}
        class Bar : MyBase {}
        
        class Program {               
            IEnumerable<IFoo> Foos { get; set; }
    
            static void Main(string[] args) {           
                List<MyBase> bases = new List<MyBase>() { new MyBase(), new MyBase() };
                List<Bar> bars = new List<Bar>() { new Bar(), new Bar() };            
                Program p = new Program();
                p.Foos = bases.Concat(bars);            
                var barsFromFoos = p.GetFoos<Bar>();
                var basesFromFoos = p.GetFoos<MyBase>();
                Debug.Assert(barsFromFoos.SequenceEqual(bars));
                Debug.Assert(basesFromFoos.SequenceEqual(bases.Concat(bars)));
                Debug.Assert(!barsFromFoos.SequenceEqual(bases));
                Console.ReadLine();
            }               
    
            public List<T> GetFoos<T>() where T : IFoo {            
                return Foos.OfType<T>().ToList();
            }
        }    
    }
