    [Serializable]
    public class OurBaseWebException : OurBaseException {
        /// <summary>
        /// Dictionary of properties relevant to the exception </summary>
        /// <remarks>
        /// Basically seals the property while leaving the class inheritable.  If we don't do this,
        /// we can't pass the dictionary to the constructors - we'd be making a virtual member call
        /// from the constructor.  This is because Microsoft makes the Data property virtual, but 
        /// doesn't expose a protected setter (the dictionary is instantiated the first time it is
        /// accessed if null).  #why
        /// If you try to fully override the property, you get a serialization exception because
        /// the base exception also tries to serialize its Data property </remarks>
        public new IDictionary Data => base.Data;
        /// <summary>The HttpStatusCode to return </summary>
        public HttpStatusCode HttpStatusCode { get; protected set; }
        public InformationSecurityWebException(SerializationInfo info, StreamingContext context) : base(info, context) {
            try {
                HttpStatusCode = (HttpStatusCode) info.GetValue("HttpStatusCode", typeof(HttpStatusCode));
            }
            catch (ArgumentNullException) {
                //  sure
            }
            catch (InvalidCastException) {
                //  fine
            }
            catch (SerializationException) {
                //  we do stuff here in the real code
            }
        }
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);            
            info.AddValue(nameof(HttpStatusCode), HttpStatusCode, typeof(HttpStatusCode));         
        }
    }
