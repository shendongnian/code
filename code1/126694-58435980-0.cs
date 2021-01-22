    using System;
    using System.Runtime.Serialization;
    
    [Serializable()]
    public class NotPrimeException : Exception
    {
       private int _notAPrime;
       public int NotAPrime { get { return _notAPrime; } }
    
       protected NotPrimeException() : base()
       { }
    
       public NotPrimeException(int value) : base(String.Format("{0} is not a prime number.", value))
       {
          _notAPrime = value;
       }
    
       public NotPrimeException(int value, string message) : base(message)
       {
          _notAPrime = value;
       }
    
       public NotPrimeException(int value, string message, Exception innerException) : base(message, innerException)
       {
          _notAPrime = value;
       }
    
       protected NotPrimeException(SerializationInfo info, StreamingContext context) : base(info, context)
       { }
    }
