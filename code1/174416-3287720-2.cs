    namespace Soapi
    {
            ///<summary>
            ///</summary>
            ///<param name = "message"></param>
            ///<param name = "statusCode"></param>
            ///<param name = "innerException"></param>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)")]
            public ApiException(string message, ErrorCode statusCode, Exception innerException)
                : base(String.Format("{0}\r\nStatusCode:{1}", message, statusCode), innerException)
            {
                this.statusCode = statusCode;
            }
