    public class Banana: Fruit
    {
       public Banana(): Fruit() // This calls the Fruit constructor
       {
           // By calling ^^^ Fruit() the inherited variable a is also = 0; 
           b = 0;
       }
       public int B { get { return b; } set { b = value; } }
       private int b;
    }
