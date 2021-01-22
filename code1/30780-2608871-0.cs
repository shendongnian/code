    /// <summary>
    /// A wrapper class for serializing exceptions.
    /// </summary>
    [Serializable] [DesignerCategory( "code" )] [XmlType( AnonymousType = true, Namespace = "http://something" )] [XmlRootAttribute( Namespace = "http://something", IsNullable = false )] public class SerializableException
    {
        #region Members
        private KeyValuePair<object, object>[] _Data; //This is the reason this class exists. Turning an IDictionary into a serializable object
        private string _HelpLink = string.Empty;
        private SerializableException _InnerException;
        private string _Message = string.Empty;
        private string _Source = string.Empty;
        private string _StackTrace = string.Empty;
        #endregion
        #region Constructors
        public SerializableException()
        {
        }
        public SerializableException( Exception exception ) : this()
        {
            setValues( exception );
        }
        #endregion
        #region Properties
        public string HelpLink { get { return _HelpLink; } set { _HelpLink = value; } }
        public string Message { get { return _Message; } set { _Message = value; } }
        public string Source { get { return _Source; } set { _Source = value; } }
        public string StackTrace { get { return _StackTrace; } set { _StackTrace = value; } }
        public SerializableException InnerException { get { return _InnerException; } set { _InnerException = value; } } // Allow null to be returned, so serialization doesn't cascade until an out of memory exception occurs
        public KeyValuePair<object, object>[] Data { get { return _Data ?? new KeyValuePair<object, object>[0]; } set { _Data = value; } }
        #endregion
        #region Private Methods
        private void setValues( Exception exception )
        {
            if ( null != exception )
            {
                _HelpLink = exception.HelpLink ?? string.Empty;
                _Message = exception.Message ?? string.Empty;
                _Source = exception.Source ?? string.Empty;
                _StackTrace = exception.StackTrace ?? string.Empty;
                setData( exception.Data );
                _InnerException = new SerializableException( exception.InnerException );
            }
        }
        private void setData( ICollection collection )
        {
            _Data = new KeyValuePair<object, object>[0];
            if ( null != collection )
                collection.CopyTo( _Data, 0 );
        }
        #endregion
    }
