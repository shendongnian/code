     void DoSomething(MyStruct str, MyClass cls)
     {
          // this will change the copy of str, but changes
          // will not be made to the outside struct
          str.Something = str.Something + 1;
          // this will change the actual class outside
          // the method, because cls points to the
          // same instance in memory
          cls.Something = cls.Something + 1;
     }
