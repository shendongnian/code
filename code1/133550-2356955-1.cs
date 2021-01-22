        public class MyClass{
    private static List<MyClass> Instances = new List<MyClass>();
    
        public MyClass(){
    lock(typeof(MyClass)){
    Instances.Add(this);
    }
    
    }}
