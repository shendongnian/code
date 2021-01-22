    using System;
    using System.Collections.Generic;
    static class Program {
        static void Main() {
            int count = Test.Count;
        }
    
        [Obsolete("Should error", true)]
        public static List<string> Test {
            get {throw new NotImplementedException();}
        }
    }
