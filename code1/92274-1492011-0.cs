    using System;
    using System.Collections.Generic;
    class Program {
        class Outer {
            static Dictionary<int, Outer> _ids = new Dictionary<int, Outer>();
            public Outer(int id) {
                _ids[id] = this;
            }
            public class Inner {
                public Outer Parent {
                    get;
                    set;
                }
                public Inner(int parentId) {
                    Parent = Outer._ids[parentId];
                }
            }
        }
        static void Main(string[] args) {
            Outer o = new Outer(1);
            Outer.Inner i = new Outer.Inner(1);
        }
    }
