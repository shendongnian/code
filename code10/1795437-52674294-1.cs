    public class PropertyRequestHandler : IRequestHandler<NewPropertyRequest, string>
        {
            public PropertyRequestHandler(IPropertyManager propertyManager, IMapper mapper)
            {
                Ensure.That(mapper).IsNotNull();
    
                _mapper = mapper;
            }
    
            private IMapper _mapper { get; }
    
            public string Handle(NewPropertyRequest message)
            {
    			var newProperty = _mapper.Map<PropertyDto>(message.NewProperty);
    			...other stuff...
            }
        }
