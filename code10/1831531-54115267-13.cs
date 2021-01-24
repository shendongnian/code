    public abstract class ImageFillSettet<T> : MonoBehaviour
    {
        // Will not appear in the Inspector
        public ValueAsset<T> ValueAsset;
        // Override this in implementation
        protected abstract void FetchValue();
        // Use it for Initializing the value
        private void Awake ()
        {
            FetchValue();
        }
        public abstract void SetFill();   
    }
