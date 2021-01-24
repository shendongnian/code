    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication52
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Class1> Obj1 = new List<Class1>();
                List<Class1> distinctClass1 = Obj1.Distinct().ToList();
            }
        }
        public class Class1 : IEquatable<Class1>
        {
            public int Class1Id { get; set; }
            public string Class1Desc { get; set; }
            public List<Class2> obj2 { get; set; }
            public Boolean Equals(Class1 other)
            {
                if (other == null) return false;
                if ((this.Class1Id == other.Class1Id) && (this.Class1Desc == other.Class1Desc) && (this.obj2 == other.obj2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class Class2 : IEquatable<Class2>
        {
            public int Class2Id { get; set; }
            public string Class2Desc { get; set; }
            public Boolean Equals(Class2 other)
            {
                if (other == null) return false;
                if ((this.Class2Id == other.Class2Id) && (this.Class2Desc == other.Class2Desc))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
