    public class Label
    {
        public Label(string trackingReference) : this(trackingReference, string.Empty)
        {
        }
        public Label(string trackingReference, string customText)
        {
            CustomText = customText;
        }
        public string CustomText ( get; private set; }
        public bool IsCustom
        {
            get
            {
                return !string.IsNullOrEmpty(CustomText);
            }
        }
    }
