    using System;
    
    namespace CsharpProject {
        public class CsharpClass {
            public string Name { get; set; }
            public int Value { get; set; }
    
            public string GetDisplayString() {
                return string.Format("{0}: {1}", this.Name, this.Value);
            }
        }
    }
