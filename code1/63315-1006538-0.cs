    using System;
    using System.Runtime.InteropServices;
    
    namespace CompareStruct {
      struct TestStruct {
        public int a, b, c;
        public TestStruct(int x, int y, int z) {
          a = x;
          b = y;
          c = z;
        }
      }
      class Program {
        static unsafe void Main(string[] args) {
    
          TestStruct x1 = new TestStruct(1, 2, 3);
          TestStruct y1 = new TestStruct(1, 2, 3);
          // this returns true
          bool fEqual1 = (RtlCompareMemory(&x1, &y1, 
           sizeof(TestStruct)) == sizeof(TestStruct));
    
          TestStruct x2 = new TestStruct(1, 2, 3);
          TestStruct y2 = new TestStruct(4,5,6);
          // this returns false
          bool fEqual2 = (RtlCompareMemory(&x2, &y2, 
           sizeof(TestStruct)) == sizeof(TestStruct));
    
        }
    
        [DllImport("ntdll.dll", SetLastError = true)]
        internal unsafe static extern int RtlCompareMemory(
         void* Source1, void* Source2, int cbLength);
      }
    }
