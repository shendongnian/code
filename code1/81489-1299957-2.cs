C#
using System;
using System.Collections.Generic;
namespace test
{
    class Program
    {
        class MyList<T> : List<T>
        {
            public event EventHandler OnAdd;
            public new void Add(T item) // "new" to avoid compiler-warnings, because we're hiding a method from base-class
            {
                if (null != OnAdd)
                {
                    OnAdd(this, null);
                }
                base.Add(item);
            }
        }
        static void Main(string[] args)
        {
            MyList<int> l = new MyList<int>();
            l.OnAdd += new EventHandler(l_OnAdd);
            l.Add(1);
        }
        static void l_OnAdd(object sender, EventArgs e)
        {
            Console.WriteLine("Element added...");
        }
    }
}
<h3>Warning</h3>
1. Be aware that you have to re-implement all methods which add objects to your list. `AddRange()` will not fire this event, in this implementation.
2. We ***did not overload*** the method. We hid the original one. If you `Add()` an object while this class is boxed in `List<T>`, the ***event will not be fired***!
MyList<int> l = new MyList<int>();
l.OnAdd += new EventHandler(l_OnAdd);
l.Add(1); // Will work
List<int> baseList = l;
baseList.Add(2); // Will NOT work!!!
