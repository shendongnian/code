    public class MyClass
    { 
        public void AccessResource()
        {
            OneAtATime(this);
        }
        private static void OneAtATime(MyClass instance) 
        { 
           if( !Monitor.TryEnter(lockObject) )
           // ...
