    public class Loader2 : ILoader {
        public SomeObject prop1 { get; set; }
        
        public Loader2(SomeObject param1) {
            prop1 = param1;
        }
    
        public void Load() {
            // Use prop1
        }
    }
