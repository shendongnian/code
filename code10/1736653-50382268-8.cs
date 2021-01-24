    public class SingleControllerFeatureProvider 
        : IApplicationFeatureProvider<ControllerFeature> {
        readonly Type m_type;
        public SingleControllerTypeResolver(Type type) => m_type = type;
        
        public void PopulateFeature(
            IEnumerable<ApplicationPart> parts,
            ControllerFeature feature) {
            if(!feature.Controllers.Contains(m_type)) {
                feature.Controllers.Add(m_type);
            }
        }
    }
