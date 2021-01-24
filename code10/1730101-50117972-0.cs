    public void ShowExample()
    {
        DateTime myValue = DateTime.Now;
        Console.WriteLine(myValue.ToString()); // 5/1/2018 10:14:20 AM
        Foo myFoo= new Foo(); // Has no ToString method
        Console.WriteLine(myFoo); // ConsoleApplication.Foo
        Bar myBar = new Bar(); // Has custom ToString method
        Console.WriteLine(myBar); // Hi I'm from ToString()
        Console.ReadLine();
    }
    public class Foo
    {
        int val = 9;
    }
    public class Bar
    {
        
        public override string ToString()
        {
            return "Hi I'm from ToString()";
        }
    }
