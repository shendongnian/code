    public interface IThumbnail
    {
       bool Visible {get; set;}
       string FilePath {get; set;}
    }
    
    public class Bar : IFoo
    {
       bool Visible {get; set;}
       int SomeNumber {get; set;}
       /* 
         rest of Bar functionality
       */
    }
    
    public class SomeClass
    {
       public void DisplayThumbnail(IThumbnail thumb)
       {
          //Do Stuff to things.
       }
    }
