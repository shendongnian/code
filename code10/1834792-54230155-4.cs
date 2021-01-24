    public class CleanUpTexture : MonoBehaviour
    {
        private RawImage rawImage;
     
        private void Awake()
        {
            rawImage = GetComponent<RawImage>();
        }
        private void OnDestroy()
        {
            if(!rawImage || rawImage.texture == null) return;
            Destroy(rawImage.texture);
        }
    }
