    public class DictionaryKeyNotValidException() : Exception
    {
       public DictionaryKeyNotValidException(string key)
           : base(GetMessage(key))
       {   
       }
    
       public ErrorEnum ErrorCode { get { return ErrorEnum.InvalidDictionaryKey; } }
    
       private string GetMessage(string key)
       {
          return string.Format("ERROR {0} : Invalid dictionary key encountered {1}",
                               ErrorCode.GetHashCode(), key);
       }
    }
