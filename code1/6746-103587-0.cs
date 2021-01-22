    using System.Collections.Generic;
    
    namespace csharp_tricks
    {
        class Program
        {
            class MyClass
            {
                int keyValue;
                int someInfo;
    
                public MyClass(int key, int info)
                {
                    keyValue = key;
                    someInfo = info;
                }
    
                public override bool Equals(object obj)
                {
                    MyClass other = obj as MyClass;
                    if (other == null) return false;
    
                    return keyValue.Equals(other.keyValue);
                }
    
                public override int GetHashCode()
                {
                    return keyValue.GetHashCode();
                }
            }
    
            class Pair<T, R>
            {
                public T First { get; set; }
                public R Second { get; set; }
            }
    
            static void Main(string[] args)
            {
                var dict = new Dictionary<Pair<int, MyClass>, object>();
    
                dict.Add(new Pair<int, MyClass>() { First = 1, Second = new MyClass(1, 2) }, 1);
    
                //this is a pair of the same values as previous! but... no exception this time...
                dict.Add(new Pair<int, MyClass>() { First = 1, Second = new MyClass(1, 3) }, 1);
    
                return;
            }
        }
    }
