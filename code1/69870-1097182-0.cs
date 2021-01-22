    public interface IZipper
    {
      void ExtractZip(string zipFilename, string folder);
      void AddFileToZip(string zipFilename, string fileToAdd);
    }
    
    public class Zipper : IZipper
    {
      public void ExtractZip(string zipFilename, string folder)
      { 
        //...
      }
    
      void AddFileToZip(string zipFilename, string fileToAdd)
      {
        //...
      }
    }
    // client code
    class Foo
    {
      private IZipper myZipper;
      // gets an instance of the zipper (injection), but implements only 
      // against the interface. Allows mocks on the IZipper interface.
      public Foo(IZipper zipper)
      {
        myZipper = zipper;
      }
    }
