    public class InvalidLoginException: Exception
    {
        public InvalidLoginException()
        {
        }
        public InvalidLoginException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }
    }
