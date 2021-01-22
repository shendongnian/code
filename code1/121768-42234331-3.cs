    public partial class MyClass {
        private int count = 0;
        public partial void NastyMethod() {
            count++;
            OnNastyMethodExecuted(count);
        }
    partial void OnNastyMethodExecuted(int Value);
    }
    
    public partial class MyClass {
        partial void OnNastyMethodExecuted(int value) {
            Console.WriteLine(value);
        }
    }
