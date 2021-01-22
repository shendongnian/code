    class Tail
    {
      DoYourThing()
    }
    
    class WaggyTail : Tail
    {
      DoYourThing()
      {
        // Wag
      }
    }
    
    class Noise
    {
      DoYourThing()
    }
    
    class Bark : Noise
    {
      DoYourThing()
      {
        // Bark
      }
    }
    
    class Talk : Noise
    {
      DoYourThing()
      {
         // Talk
      }
    }
    
    class Animal
    {
       public Noise { get; set; }
       public Tail { get; set; }
    }
