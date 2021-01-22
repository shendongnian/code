    public class MyClass{
      public MyClass(){
        if(this.GetType().Assembly != typeof(MyClass).Assembly){
            throw new Exception("Can't derive from this type!");
      }
    }
