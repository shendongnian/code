    // Unchanged
    public class BasicLabel : ILabel
    {
        public string TrackingReference { get; private set; }
    
        public BasicLabel(string trackingReference)
        {
            TrackingReference = trackingReference;
        }
    }
    // ADDED THE NULL OR EMPTY CHECK
    public class CustomLabel : ILabel
    {
        public string TrackingReference { get; private set; }
        public string CustomText { get; private set; }
    
        public CustomLabel(string trackingReference, string customText)
        {
            TrackingReference = trackingReference;
            if(customText.IsNullOrEmpty()){
               throw new SomeException();
            }
            CustomText = customText;
        }
    }
    public class LabelFactory
    {
        public ILabel CreateLabel(string trackingReference)
        {
             return new BasicLabel(trackingReference);
        }
    
        public ILabel CreateLabel(string trackingReference, string customText)
        {
             return new CustomLabel(trackingReference, customText);
        }
    }
