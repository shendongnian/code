    public class SomeLibraryClassGateway : ISomeLibraryClassGateway {
      private readonly SomeLibraryClass slc;
      public SomeLibraryClassGateway(SomeLibraryClass slc) {
        this.slc = slc;
      }
      void ISomeLibraryClassGateway.WriteMessage(string message) {
        slc.WriteMessage(message);
      }
    }
