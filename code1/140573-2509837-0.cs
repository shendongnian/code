    public interface ISlice
    {
        bool DoStuff(string someParameter);
    }
    
    public class MySpecificSliceOfType : ISlice
    {
        // this must have a method implementation for the [bool DoStuff(string)] method
        public bool DoStuff(string mySpecificParameter)
        {
           // LOGIC in the Specific class
           return(true);
        }
    }
    
    public class MyOtherSliceOfType : ISlice
    {
        // this must have a method implementation for the [bool DoStuff(string)] method
        public bool DoStuff(string myOtherParameter)
        {
           // LOGIC in the Other class
           return(true);
        }
    }
