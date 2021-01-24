    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly IEndpointAddressScheme<RouteValuesAddress> _endpointAddress;
    
        public MetadataController(
            IMetadataProvider metadataProvider,
            IEndpointAddressScheme<RouteValuesAddress> endpointAddress)
        {
            _metadataProvider = metadataProvider;
            _endpointAddress = endpointAddress;
        }
    
        [HttpGet]
        public IActionResult GetMetadata()
        {
            var metadata = _metadataProvider.GetMetadata();
            // EXPECTED: "api/metadata/{name}"
            // ACTUAL: "api/metadata/{name}"
            string actionName = nameof(MetadataController.GetById);
            string controllerName = nameof(MetadataController).Replace(nameof(Controller), string.Empty);
            var url = _endpointAddress.FindEndpoints(CreateAddress(actionName, controllerName))
                .OfType<RouteEndpoint>()
                .Select(x => x.RoutePattern)
                .FirstOrDefault();;
    
            var response = new HALResponse(metadata)
                .AddSelfLink(HttpContext.Request)
                .AddLinks(new Link(name, url));
    
            return Ok(response);
        }
    
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var metadata = _metadataProvider.GetMetadataForEntity(name);
            return Ok(metadata);
        }
        private static RouteValuesAddress CreateAddress(string action, string controller)
        {
            var explicitValues = new RouteValueDictionary(null);
            var ambientValues = GetAmbientValues(httpContext);
            explicitValues ["action"] = action;
            explicitValues ["controller"] = controller;
            return new RouteValuesAddress()
            {
                AmbientValues = ambientValues,
                ExplicitValues = explicitValues
            };
        }
    }
