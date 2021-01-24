    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
        namespace ConsoleApp5
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var A = new MyDictKey(1, 1);
                    var B = new MyDictKey(1, -1);
                    var C = new MyDictKey(1, 2);
        
                    var h = new HashSet<MyDictKey>();
                    h.Add(A);
                    h.Add(B);
                    h.Add(C);
                    Console.WriteLine(h.Count); //outputs 2
        
        
                    var h2 = new HashSet<MyDictKey>();
                    h2.Add(B);
                    h2.Add(C);
                    h2.Add(A);
                    Console.WriteLine(h2.Count); //outputs 1
        
                    Console.ReadKey();
        
                }
        
                public sealed class MyDictKey
                {
                    public int Type { get; }
                    public int SubType { get; }
        
                    public MyDictKey(int type, int subType) // both can only be positive values
                    {
                        Type = type;
                        SubType = subType;
                    }
        
                    public override bool Equals(object obj)
                    {
                        if (obj is MyDictKey other)
                        {
                            bool typeEqual = other.Type == Type;
                            bool subTypeEqual = other.SubType == -1 || SubType == -1 || other.SubType == SubType;
                            return typeEqual && subTypeEqual;
                        }
        
                        return false;
                    }
        
                    public override int GetHashCode()
                    {
                        unchecked
                        {
                            int hash = 17;
                            hash = hash * 23 + Type.GetHashCode();
                            return hash;
                        }
                    }
                }
            }
        }
