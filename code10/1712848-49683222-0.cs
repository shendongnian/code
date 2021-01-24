    internal sealed class MySerializerProvider : DefaultODataSerializerProvider
    {
        private MySerializer _mySerializer;
        public MySerializerProvider(IServiceProvider sp) : base(sp)
        {
            _mySerializer = new MySerializer(this);
        }
        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            var fullName = edmType.FullName();
                   
            if (fullName == "Namespace.Bar")
                return _mySerializer;            
            else
                return base.GetEdmTypeSerializer(edmType);            
        }        
    }
