    public class Example : MonoBehaviour
    {
        private Texture2D _texture;
        private TextureFormat _format = TextureFormat.ARGB32;
        private void Awake()
        {
            _texture = new Texture2D(width, height, _format, false);
        }
        private void Update()
        {
            using (var image = Frame.CameraImage.AcquireCameraImageBytes())
            {
                if (!image.IsAvailable) return;
                // Load the data into a texture 
                // (this is an expensive call, but it may be possible to optimize...)
                _texture.LoadRawTextureData(image);
                _texture.Apply();
            }
        }
        public void SaveImage()
        {
            _texture.EncodeToJPG();
        }
    }
