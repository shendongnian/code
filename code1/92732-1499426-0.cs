    [Serializable]
    public class CustomException : Exception
    {
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomException"/> class.
    /// </summary>
    public CustomException()
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomException"/> class with
    /// a specified error message.
    /// </summary>
    public CustomException(string message) : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomException"/> class with
    /// a specified error message and a reference to the inner exception that is a cause
    /// of this exception.
    /// </summary>
    public CustomException(string message, Exception inner) : base(message, inner)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomException"/> class with
    /// serialized data.
    /// </summary>
    protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    
    }
