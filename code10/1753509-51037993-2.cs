    public class Loader1 : ILoader {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        
        public Loader1(string param1, string param2) {
            prop1 = param1;
            prop2 = param2;
        }
    
        public void Load() {
            // Use prop1 and prop2
        }
    }
    
