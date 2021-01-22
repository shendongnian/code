    public class MyClass
    {
      event Action MyEvent;
    }
    ...
    MyClass myClass = new MyClass();
    myClass.MyEvent += SomeFunction;
    ...
    Action[] handlers = myClass.GetInvocationList(); //this will be an array of 1 in this example
    Console.WriteLine(handlers[0].Method.Name);//prints the name of the method
