    public abstract class CProgressBar : MonoBehaviour
    {
        protected abstract RawImage RawImg
        {
            get;
        }
        protected abstract Material Mat
        {
            get;
        }
    }
    
    public class ProgressBar : CProgressBar
    {
        protected override RawImage RawImg => null;
        protected override Material Mat => null;
    }
