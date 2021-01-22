        class Program
        {
            static void Main( string[] args )
            {
                Console.WriteLine (Fruit.CreateFruit<Apple> ().Define ());
                Console.WriteLine (Fruit.CreateFruit<Orange> ().Define ());
    
                Console.ReadLine ();
            }        
        }
