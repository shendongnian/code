    struct Refsample<T> where T : class
    {
       // stored in the stack as well.
       public int Age; 
       
       // memory address pointing to the heap stored in the stack, 
       // but the actual object is stored in the heap.
       public string Name；
       // same as string above if T was reference type;
       // otherwise, if value type, same as Age above.
       public T SomeThing; 
    }
