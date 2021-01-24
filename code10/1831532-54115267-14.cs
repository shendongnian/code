    public class ImageFillSetterFloat : ImageFillSetter<float>
    {
        // Show in the inspector
        [SerializeField] private FloatValue valueReference;
        // Provide the reference to the base class
        protected override void Fetch value()
        {
            valueAsset = valueReference;
        }
        public override void SetFill()
        {
            // Use valueReference for something
        }
    }
