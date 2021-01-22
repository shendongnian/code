    [Serializable]
    public abstract class ElementBase
    {
        // This constructor sets up the default namespace for all of my objects. Every
        // Xml Element class will inherit from this class.
        internal ElementBase()
        {
            this._namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
                new XmlQualifiedName(string.Empty, "urn:my-default-namespace:XSD:1")
            });
        }
        [XmlNamespacesDeclaration]
        public XmlSerializerNamespaces Namespaces { get { return this._namespaces; } }
        private XmlSerializationNamespaces _namespaces;
    }
    [Serializable]
    public abstract class ServiceBase : ElementBase
    {
        private ServiceBase() { }
        public ServiceBase(Guid requestId, Guid? asyncRequestId = null, Identifier name = null)
        {
            this._requestId = requestId;
            this._asyncRequestId = asyncRequestId;
            this._name = name;
        }
        public Guid RequestId
        {
            get { return this._requestId;  }
            set { this._requestId = value;  }
        }
        private Guid _requestId;
        public Guid? AsyncRequestId
        {
            get { return this._asyncRequestId; }
            set { this._asyncRequestId = value; }
        }
        private Guid? _asyncRequestId;
        public bool AsyncRequestIdSpecified
        {
            get { return this._asyncRequestId == null && this._asyncRequestId.HasValue; }
            set { /* XmlSerializer requires both a getter and a setter.*/ ; }
        }
        public Identifier Name
        {
            get { return this._name; }
            set { this._name; }
        }
        private Identifier _name;
    }
    [Serializable]
    public abstract class ServiceResponseBase : ServiceBase
    {
        private ServiceBase _serviceBase;
        private ServiceResponseBase() { }
        public ServiceResponseBase(Guid requestId, Guid? asyncRequestId = null, Identifier name = null, Status status = null)
        {
            this._serviceBase = new ServiceBase(requestId, asyncRequestId, name);
            this._status = status;
        }
        public Guid RequestId
        {
            get { return this._serviceBase.RequestId; }
            set { this._serviceBase.RequestId = value; }
        }
        public Guid? AsyncRequestId
        {
            get { return this._serviceBase.AsyncRequestId; }
            set { this._serviceBase.AsyncRequestId = value; }
        }
        public bool AsynceRequestIdSpecified
        {
            get { return this._serviceBase.AsyncRequestIdSpecified; }
            set { ;  }
        }
        public Identifier Name
        {
            get { return this._serviceBase.Name; }
            set { this._serviceBase.Name = value; }
        }
        public Status Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
    }
    [Serializable]
    [XmlRoot(Namespace = "urn:my-default-namespace:XSD:1")]
    public class BankServiceResponse : ServiceResponseBase
    {
        // Determines if the class is being deserialized.
        private bool _isDeserializing;
        private ServiceResponseBase _serviceResponseBase;
        // Constructor used by XmlSerializer.
        // This is special because I require a non-null List<T> of items later on.
        private BankServiceResponse()
        { 
            this._isDeserializing = true;
            this._serviceResponseBase = new ServiceResponseBase();
        }
        // Constructor used for unit testing
        internal BankServiceResponse(bool isDeserializing = false)
        {
            this._isDeserializing = isDeserializing;
            this._serviceResponseBase = new ServiceResponseBase();
        }
        public BankServiceResponse(Guid requestId, List<BankResponse> responses, Guid? asyncRequestId = null, Identifier name = null, Status status = null)
        {
            if (responses == null || responses.Count == 0)
                throw new ArgumentNullException("The list cannot be null or empty", "responses");
            this._serviceResponseBase = new ServiceResponseBase(requestId, asyncRequestId, name, status);
            this._responses = responses;
        }
        [XmlElement(Order = 1)]
        public Status Status
        {
            get { return this._serviceResponseBase.Status; }
            set { this._serviceResponseBase.Status = value; }
        }
        [XmlElement(Order = 2)]
        public Guid RequestId
        {
            get { return this._serviceResponseBase.RequestId; }
            set { this._serviceResponseBase.RequestId = value; }
        }
        [XmlElement(Order = 3)]
        public Guid? AsyncRequestId
        {
            get { return this._serviceResponseBase.AsyncRequestId; }
            set { this._serviceResponseBase.AsyncRequestId = value; }
        }
        [XmlIgnore]
        public bool AsyncRequestIdSpecified
        {
            get { return this._serviceResponseBase.AsyncRequestIdSpecified; }
            set { ; } // Must have this for XmlSerializer.
        }
        [XmlElement(Order = 4)]
        public Identifer Name
        {
             get { return this._serviceResponseBase.Name; }
             set { this._serviceResponseBase.Name; }
        }
        [XmlElement(Order = 5)]
        public List<BankResponse> Responses
        {
            get { return this._responses; }
            set
            {
                if (this._isDeserializing && this._responses != null && this._responses.Count > 0)
                    this._isDeserializing = false;
                if (!this._isDeserializing && (value == null || value.Count == 0))
                    throw new ArgumentNullException("List cannot be null or empty.", "value");
                this._responses = value;
            }
        }
        private List<BankResponse> _responses;
    }
