    public class SingleControllerFeatureProvider : ControllerFeatureProvider {
        readonly Type m_type;
        public SingleControllerTypeResolver(Type type) => m_type = type;
        protected override bool IsController(TypeInfo typeInfo) {
           return base.IsController(typeInfo) && typeInfo == m_type.GetTypeInfo();
        }
    }
    
