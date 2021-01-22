    public class Myclass()
    {
        private string _property;
        public MyClass(MyClass obj)
        {
             this.InjectFrom(obj.DeepClone());
        }
    }
