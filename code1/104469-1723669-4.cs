    public abstract class ClassA<T> where T: ClassA<T>, new()
    {
        public abstract T DoSomethingAndReturnNewObject();
    }
    
    public class ClassB: ClassA<ClassB>
    {
        public override ClassB DoSomethingAndReturnNewObject()
        {
            //do whatever
        }
    }
