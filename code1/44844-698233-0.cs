    public class LabelFactory {
        public ILabel CreateLabel(string trackingReference, string customText) {
            return new CustomLabel(trackingReference, customText);
        }
    
        public ILabel CreateLabel(String trackingReference) {
            return new BasicLabel(trackingReference);
        }
    }
