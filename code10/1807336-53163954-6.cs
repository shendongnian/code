    public class Class1 : IConnectionOption {
        private readonly DatabaseSettings test;
    
        public Class1(DatabaseSettings settings) {
            test = settings;    
        }    
    
        public void ReadValue() {
            var r = test;
            //...
        }
    }
