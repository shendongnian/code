    // this is the interface, or the "contract".  It guarantees
    // that anything that implements IMeowingCat will have a void
    // that takes no parameters, named Meow.
    public class IMeowingCat
    {
        void Meow();
    }
   
    // this class, which implements IMeowingCat is the "interface implementation".  
    // *You* write the code in here. 
    public class MeowingCat : IMeowingCat
    {
        public void Meow
        {
            Console.WriteLine("Meow.  I'm hungry");
        }
    }
