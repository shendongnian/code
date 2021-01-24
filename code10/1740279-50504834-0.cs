		public static async Task ScanConnection()
		{
				MobileBarcodeScanningOptions options = new ZXing.Mobile.MobileBarcodeScanningOptions()
					{
						TryHarder = true,
						PossibleFormats = new List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE }
					};
					MobileBarcodeScanner scanner = new ZXing.Mobile.MobileBarcodeScanner();
					ZXing.Result result = await scanner.Scan(options);
			
					if (result != null && !string.IsNullOrEmpty(result.Text))
					{
						...
					}
		}
   
