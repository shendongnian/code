    public class Banana 
    {
        public Banana(string color)
        {
            if ( color == "red" )
              throw new SomeException("intialization failed, red is an invalid color");
    
        }
    }
    //////////////////////////////////////////////////////////     
    try
    {
        Banana banana1 = new Banana("green");
        banana1.whatever();
    }
    catch( SomeException error )
    {
        // do something
    }
    finally
    {
        // always do  this stuff
    }
