    public class QRCodeReader : MonoBehaviour
    {
        public Camera cam;
        private BarcodeReader barCodeReader;
    
        FrameCapturer m_pixelCapturer;
    
        // Use this for initialization
        void Start()
        {
            barCodeReader = new BarcodeReader();
            Resolution currentResolution = Screen.currentResolution;
            m_pixelCapturer = cam.GetComponent<FrameCapturer>();
        }
    
        void Update()
        {
    
            Resolution currentResolution = Screen.currentResolution;
    
            try
            {
                Color32[] framebuffer = m_pixelCapturer.m_lastCapturedColors;
                if (framebuffer.Length == 0)
                {
                    return;
                }
    
                var data = barCodeReader.Decode(framebuffer, currentResolution.width, currentResolution.height);
                if (data != null)
                {
                    // QRCode detected.
                    Debug.Log(data);
                    Debug.Log("QR: " + data.Text);
    
                    //OnQrCodeRead(new QrCodeReadEventArgs() { text = data.Text });
                }
    
            }
            catch (Exception e)
            {
                Debug.LogError("Error reading QR");
                Debug.LogError(e.Message);
            }
    
            // skip 1 frame each time 
            // solves GetPixels() blocks for ReadPixels() to complete
            // https://medium.com/google-developers/real-time-image-capture-in-unity-458de1364a4c
            m_pixelCapturer.m_shouldCaptureOnNextFrame = true;
    
        }
    }
