    public abstract class ClassA<T> where T: ClassA, new
    {
        public virtual T DoSomethingAndReturnNewObject();
    }
    
    public class ClassB: ClassA<ClassB>
    {
        public override ClassB DoSomethingAndReturnNewObject()
        {
            //do whatever
        }
    }
