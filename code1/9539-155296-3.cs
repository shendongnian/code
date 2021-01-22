    public class Adder<T>
    {
       public T AddTwoThings(T t1, T t2)
       {
           return t1 + t2;
       }
    }
    
    Adder<String> stringAdder = new Adder<String>();
    Console.Writeline(stringAdder.AddTwoThings("Test,"123"));
    
    Adder<int> intAdder = new Adder<int>();
    Console.Writeline(intAdder.AddTwoThings(2,2));
