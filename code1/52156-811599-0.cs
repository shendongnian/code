    public interface IControlProvider {
        public Control GetControl(XmlElement controlXml);
    };
    public class ControlProviderFactory : IControlProvider {
        private Dictionary<string,IControlProvider> providers = new Dictionary<string,IControlProvider>();
        public ControlProviderFactory() {
            //Add concrete implementations of IControlProvider for each type
        }
        public Control GetControl(XmlElement controlXml) {
            string type = (controlXml.SelectSingleNode("type") as XmlElement).InnerText;
            if(!providers.ContainsKey(type) throw new Exception("No provider exists for " + type);
            return providers[type].GetControl(controlXml);
        }
    }
