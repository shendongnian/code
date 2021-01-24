    public abstract class CProgressBar : MonoBehaviour
    {
        public virtual RawImage RawImg
        {
            get;
            protected set;
        }
        public virtual Material Mat
        {
            get;
            protected set;
        }
    }
    public class ProgressBar : CProgressBar
    {
        public ProgressBar()
        {
            Mat = null;
            RawImg = null;
        }
    }
