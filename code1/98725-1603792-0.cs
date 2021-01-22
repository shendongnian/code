    using System;
    
    public class ArrayWrapper {
    
        private string[] _arr;
    
        public ArrayWrapper(string[] arr) { //ctor
            _arr = arr;
        }
    
        public string this[int i] { //indexer - read only
            get {
                return _arr[i];
            }
        }
    }
    
    // SAMPLE of using the wrapper
    static class Sample_Caller_Code {
        static void Main() {
            ArrayWrapper wrapper = new ArrayWrapper(new[] { "this", "is", "a", "test" });
            string strValue = wrapper[2]; // "a"
            Console.Write(strValue);
        }
    }
