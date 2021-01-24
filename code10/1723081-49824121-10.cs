    public class GaussianBlur : IFilter
    {
        private GaussianBlurParams p;
        public GaussianBlur(GaussianBlurParams filterParams)
            : base(filterParams)
        {
        }
        public override void Apply(ref Mat buffer)
        {
            Cv2.GaussianBlur(buffer, buffer, p.KernelSize, p.SigmaX, p.SigmaY, p.BorderType);
        }
    }
    public class GaussianBlurParams
    {
        public Size KernelSize = new Size(5, 5);
        public double SigmaX = default(double);
        public double SigmaY = default(double);
        public BorderTypes BorderType = BorderTypes.Default;
    }
