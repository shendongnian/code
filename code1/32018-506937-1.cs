    [WebService]
    public class ProcessingWebService
    {
        public void ProcessFoo( FooDataObject foo )
        {
            // you'd need a constructor to convert the DAO
            // to a Processable object.
            IProcessable fooProc = new FooProcessable( foo );
            fooProc.Process();
        }
    }
