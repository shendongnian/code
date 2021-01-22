    [Serializable]
    public class AddMediaCategoryRequest : IRequest<AddMediaCategoryResponse>
    {
        private readonly Guid _parentCategory;
        private readonly string _label;
        private readonly string _description;
        public AddMediaCategoryRequest(Guid parentCategory, string label, string description)
        {
            _parentCategory = parentCategory;
            _description = description;
            _label = label;
        }
        public string Description
        {
            get { return _description; }
        }
        public string Label
        {
            get { return _label; }
        }
        public Guid ParentCategory
        {
            get { return _parentCategory; }
        }
    }
    [Serializable]
    public class AddMediaCategoryResponse : Response 
    {
        public Guid ID;
    }
    public interface IRequest<T> : IRequest where T : Response, new() {}
    [Serializable]
    public class Response
    {
        protected bool _success;
        private string _failureMessage = "This is the default error message.  If a failure has been reported, it should have overwritten this message.";
        private Exception _exception;
        public Response()
        {
            _success = false;
        }
        public Response(bool success)
        {
            _success = success;
        }
        public Response(string failureMessage)
        {
            _failureMessage = failureMessage;
        }
        public Response(string failureMessage, Exception exception)
        {
            _failureMessage = failureMessage;
            _exception = exception;
        }
        public bool Success
        {
            get { return _success; }
        }
        public string FailureMessage
        {
            get { return _failureMessage; }
        }
        public Exception Exception
        {
            get { return _exception; }
        }
        public void Failed(string failureMessage)
        {
            _success = false;
            _failureMessage = failureMessage;
        }
        public void Failed(string failureMessage, Exception exception)
        {
            _success = false;
            _failureMessage = failureMessage;
            _exception = exception;
        }
    }
    public class AddMediaCategoryRequestHandler : IRequestHandler<AddMediaCategoryRequest,AddMediaCategoryResponse>
    {
        private readonly IMediaCategoryRepository _mediaCategoryRepository;
        public AddMediaCategoryRequestHandler(IMediaCategoryRepository mediaCategoryRepository)
        {
            _mediaCategoryRepository = mediaCategoryRepository;
        }
        public AddMediaCategoryResponse HandleRequest(AddMediaCategoryRequest request)
        {
            MediaCategory parentCategory = null;
            MediaCategory mediaCategory = new MediaCategory(request.Description, request.Label,false);
            Guid id = _mediaCategoryRepository.Save(mediaCategory);
            if(request.ParentCategory!=Guid.Empty)
            {
                parentCategory = _mediaCategoryRepository.Get(request.ParentCategory);
                parentCategory.AddCategoryTo(mediaCategory);
            }
            AddMediaCategoryResponse response = new AddMediaCategoryResponse();
            response.ID = id;
            return response;
        }
    }
