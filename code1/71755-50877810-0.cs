    public class MyClass {
         public List<int> MyIntList { get; set; }
         MyClass() {
    
         }
         MyClass(int i) {
              MyIntList = new List<int>();
              MyIntList.Add(int i);
         }
    }
