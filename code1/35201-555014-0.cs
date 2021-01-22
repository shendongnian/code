    using System;
    
    namespace simpletest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Bird sparrow = new Bird();
                Console.WriteLine("Is the bird flying? " + sparrow.IsFlying + "\n");
    
                Console.WriteLine("Make the bird fly.");
                sparrow.Fly();
                Console.WriteLine("Is the bird flying? " + sparrow.IsFlying + "\n");
    
                Console.WriteLine("Make the bird land.");
                sparrow.Land();
                Console.WriteLine("Is the bird flying? " + sparrow.IsFlying);
                Console.ReadLine();
            }
        }
    
        public abstract class Animal
        {
            bool _isMoving = false;
    
            protected bool IsMoving
            {
              get { return _isMoving; }
            }
            
            protected void StartMoving()
            {
                _isMoving = true;
            }
            
            protected void StopMoving()
            {
                _isMoving = false;
            }
        }
    
        public class Bird : Animal, IFlyable
        {
            public void Fly()
            {
                base.StartMoving();
            }
    
            public void Land()
            {
                base.StopMoving();
            }
    
            public bool IsFlying
            {
                get { return base.IsMoving; }
            }
        }
    
       interface IFlyable
       {
           void Fly();
           bool IsFlying { get; }
           void Land();
       }
    }
