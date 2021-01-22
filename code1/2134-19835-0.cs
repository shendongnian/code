    using System;
    
    public class Example
    {
        public class Toy
        {
            private bool inCupboard = false;
            public void Play() { Console.WriteLine("Playing."); }
            public void PutAway() { inCupboard = true; }
            public bool IsInCupboard { get { return inCupboard; } }
        }
        
        public delegate void ToyUseCallback(Toy toy);
        
        public class Parent
        {
            public static void RequestToy(ToyUseCallback callback)
            {
                Toy toy = new Toy();
                callback(toy);
                if (!toy.IsInCupboard)
                {
                    throw new Exception("You didn't put your toy in the cupboard!");
                }
            }
        }
        
        public class Child
        {
            public static void Play()
            {
                Parent.RequestToy(delegate(Toy toy)
                {
                    toy.Play();
                    // Oops! Forgot to put the toy away!
                });
            }
        }
        
        public static void Main()
        {
            Child.Play();
            Console.ReadLine();
        }
    }
