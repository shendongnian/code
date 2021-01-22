    import system;
    class Father
    {
        Speak()
        {
      	    Console.Writeline("Father is speaking")	
        }
        virtual Scream()
        {
          	Console.Writeline("Father is screaming")	
        }
    }
    class Child: father
    {
        Speak()
        {
      	    Console.Writeline("Child is speaking")	
        }
        override Scream()
        {
      	    Console.Writeline("Child is screaming")	
        }
    }
    class APP
    {
        public static void Main()
        {
            // We new two instances here
            Father father = new Father();
            Child child = new Child();        
            // Here we call their scream or speak through TryScream or TrySpeak
            TrySpeak(father);
            TrySpeak(child);
            //>>>"Father is speaking"
            //>>>"Father is speaking"
            TryScream(father);
            TryScream(child);
            //>>>"Father is screaming"
            //>>>"Child is screaming"
        }
        // when your method take an Parameter who type is Father
        // You can either pass in a Father instance or
        // A instance of a derived Class from Father
        // which could be Child
        public static void TrySpeak(Father person)
        {
            person.Scream();
        }
        public static void TryScream(Father person)
        {
            person.Speak();
        }
    }
