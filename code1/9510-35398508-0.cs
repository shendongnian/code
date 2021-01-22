    namespace MyExample {
       public class Memory {
          public static readonly Register = new MemoryRegister();
          public class MemoryRegister {
             private int[] _values = new int[100];
             
             public int this[int index] {
                get { return _values[index]; }
                set { _values[index] = value; }
             }
          }
       }
    }
