    public class OracleTypeException : SystemException, _Exception
    {
        public virtual Type GetType()
        {
            throw new NotImplementedException();
        }
    
        Type _Exception.GetType()
        {
            throw new NotImplementedException();
        }
    }
