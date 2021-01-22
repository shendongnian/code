    public interface IDocumentation
    {
        // Add whatever functionality you need from RemoteDoc.Documentation
    }
    
    public class RemoteDocumnetation : IDocumentation
    {
        private RemoteDoc.Documentation docService = new RemoteDoc.Documentation();
        // Implements IDocumentation 
    }
    
    public class Test{
            private IDocumentation doc;
            public Test(IDocumentation serv)
            {
                   doc= serv;
            }
    }
