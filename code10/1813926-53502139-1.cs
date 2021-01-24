    private string DecodeQR(Color32[] pixels, int width, int height)
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
			var result = barcodeReader.Decode(pixels, width, height);
            if (result != null)
            {
                return result.Text;
            }
        }
        catch (Exception ex) { Debug.LogError(ex.Message); }
        return null;
    }
	[SerializeField] Text QrDisplay; // A text field to display detected QRs to
	public void OnQrDetect() // a callback for a UI button
	{
		var texture = new Texture2D(_webcamFetcher.RenderTexture.width, _webcamFetcher.RenderTexture.height);
		RenderTexture.active = _webcamFetcher.RenderTexture;
		texture.ReadPixels(new Rect(Vector2.zero, new Vector2(_webcamFetcher.RenderTexture.width, _webcamFetcher.RenderTexture.height)), 0, 0);
      
		var qrText = DecodeQR(texture.GetPixels32(), _webcamFetcher.RenderTexture.width, _webcamFetcher.RenderTexture.height);
        if (qrText != null)
        {
            QrDisplay.text = qrText;
        }
	}
