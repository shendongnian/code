    public partial class MyClass {
        private int count = 0;
        public partial void NastyMethod() {
            count++;
        }
    }
    
    public partial class MyClass {
        public partial void NastyMethod() {
            Console.WriteLine(count);
        }
    }
       
    
