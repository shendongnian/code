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
                List<Class1> Obj1 = new List<Class1> {
                    new Class1() { Class1Desc = "A", Class1Id = 1, obj2 = new List<Class2>() { new Class2() { Class2Id = 100, Class2Desc= "M"}}},
                    new Class1() { Class1Desc = "B", Class1Id = 1, obj2 = new List<Class2>() { new Class2() { Class2Id = 100, Class2Desc= "M"}}},
                    new Class1() { Class1Desc = "A", Class1Id = 1, obj2 = new List<Class2>() { new Class2() { Class2Id = 100, Class2Desc= "M"}}},
                    new Class1() { Class1Desc = "A", Class1Id = 1, obj2 = new List<Class2>() { new Class2() { Class2Id = 200, Class2Desc= "M"}}}
                };
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
                if ((this.Class1Id == other.Class1Id) && (this.Class1Desc == other.Class1Desc) && (this.obj2.OrderBy(x => x).SequenceEqual(other.obj2.OrderBy(x => x))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return (this.Class1Id.ToString() + "^" + this.Class1Desc + string.Join("^", obj2.Select(x => x.GetHashCodeStr()))).GetHashCode();
            }
        }
        public class Class2 : IEquatable<Class2> , IComparer<Class2>
        {
            public int Class2Id { get; set; }
            public string Class2Desc { get; set; }
            public Boolean Equals(Class2 other)
            {
                if(other == null) return false;
                if ((this.Class2Id == other.Class2Id) && (this.Class2Desc == other.Class2Desc))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int Compare(Class2 x, Class2 y)
            {
                int results = 0;
                results = x.Class2Id.CompareTo(y.Class2Id);
                if (results == 0)
                {
                    results = x.Class2Desc.CompareTo(y.Class2Desc);
                }
                return results;
            }
            public override int GetHashCode()
            {
                return (this.Class2Id.ToString() + "^" + this.Class2Desc).GetHashCode();
            }
            public string GetHashCodeStr()
            {
                return this.Class2Id.ToString() + "^" + this.Class2Desc;
            }
     
        }
    }
