    public abstract class CProgressBar : MonoBehaviour
    {
        protected virtual RawImage _rawImg
        {
            get => rawImg;
            private set => rawImg = value;
        }
        protected virtual Material _mat
        {
            get => mat;
            private set => mat = value;
        }
        private RawImage rawImg;
        private Material mat;
    }
    public class ProgressBar : CProgressBar
    {
        protected override RawImage _rawImg => null;
        protected override Material _mat => null;
    }
