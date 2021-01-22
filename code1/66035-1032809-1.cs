    /// <summary>
    /// Drive error exception class. Thrown when a drive selection error has occured.
    /// </summary>
    [Serializable]
    public class DriveException : ApplicationException
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DriveException()
        {
        }
        /// <summary>
        /// Constructor used with a message.
        /// </summary>
        /// <param name="message">String message of exception.</param>
        public DriveException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// Constructor used with a message and an inner exception.
        /// </summary>
        /// <param name="message">String message of exception.</param>
        /// <param name="inner">Reference to inner exception.</param>
        public DriveException(string message, Exception inner)
            : base(message, inner)
        {
        }
        /// <summary>
        /// Constructor used in serializing the data.
        /// </summary>
        /// <param name="info">Data stored to serialize/de-serialize</param>
        /// <param name="context">Defines the source/destinantion of the straeam.</param>
        public DriveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
