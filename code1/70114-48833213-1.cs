    using MyType;
    public class Somewhere 
    {
        public void Consuming(){
            // through instance of your type
            var myObject = new MyType(); 
            var alpha = myObject.MyProperty;
            // through your type 
            var beta = MyType.MyStatic;
        }
    }       
