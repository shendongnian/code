    public class SomeRelatedLibraryClassGateway : ISomeRelatedLibraryClassGateway {
      private readonly SomeRelatedLibraryClass srlc;
      public SomeRelatedLibraryClassGateway(SomeRelatedLibraryClass srlc) {
        this.srlc = srlc;
      }
      void ISomeRelatedLibraryClassGateway.WriteMessage(string message) {
        srlc.WriteMessage(message);
      }
    }
