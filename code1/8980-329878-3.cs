    class MyContextInformation : IDisposable {
        [ThreadStatic] private static MyContextInformation current;
    
        public static MyContextInformation Current {
            get { return current; }
        }
        private MyContextInformation previous;
    
    
        public MyContextInformation(Object myData) {
           this.myData = myData;
           previous = current;
           current = this;
        }
    
        public void Dispose() {
           current = previous;
        }
    }
