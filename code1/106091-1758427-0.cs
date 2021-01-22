    // a simple enum
    public enum TransmissionStatus
    {
        Success = 0,
        Failure = 1,
        Error = 2,
    }
    // a consumer of enum
    public class MyClass 
    {
        public void ProcessTransmissionStatus (TransmissionStatus status)
        {
            ...
            // an exhaustive switch statement, but only if
            // enum remains the same
            switch (status)
            {
                case TransmissionStatus.Success: ... break;
                case TransmissionStatus.Failure: ... break;
                case TransmissionStatus.Error: ... break;
                // should never be called, unless enum is 
                // extended - which is entirely possible!
                // remember, code defensively! future proof!
                default:
                    throw new NotSupportedException ();
                    break;
            }
            ...
        }
    }
