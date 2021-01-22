	{
		using System;
		using System.Linq;
		using System.Threading.Tasks;
		using System.Windows;
		using Windows.Devices.Enumeration;
		using Windows.Devices.PointOfService;
		using Windows.Storage.Streams;
		using PosBarcodeScanner = Windows.Devices.PointOfService.BarcodeScanner;
		public class BarcodeScanner : IBarcodeScanner, IDisposable
		{
			private ClaimedBarcodeScanner scanner;
			public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
			~BarcodeScanner()
			{
				this.Dispose(false);
			}
			public bool Exists
			{
				get
				{
					return this.scanner != null;
				}
			}
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}
			public async Task StartAsync()
			{
				if (this.scanner == null)
				{
					var collection = await DeviceInformation.FindAllAsync(PosBarcodeScanner.GetDeviceSelector());
					if (collection != null && collection.Count > 0)
					{
						var identity = collection.First().Id;
						var device = await PosBarcodeScanner.FromIdAsync(identity);
						if (device != null)
						{
							this.scanner = await device.ClaimScannerAsync();
							if (this.scanner != null)
							{
								this.scanner.IsDecodeDataEnabled = true;
								this.scanner.ReleaseDeviceRequested += WhenScannerReleaseDeviceRequested;
								this.scanner.DataReceived += WhenScannerDataReceived;
								await this.scanner.EnableAsync();
							}
						}
					}
				}
			}
			private void WhenScannerDataReceived(object sender, BarcodeScannerDataReceivedEventArgs args)
			{
				var data = args.Report.ScanDataLabel;
			
				using (var reader = DataReader.FromBuffer(data))
				{
					var text = reader.ReadString(data.Length);
					var bsea = new BarcodeScannedEventArgs(text);
					this.BarcodeScanned?.Invoke(this, bsea);
				}
			}
			private void WhenScannerReleaseDeviceRequested(object sender, ClaimedBarcodeScanner args)
			{
				args.RetainDevice();
			}
			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					this.scanner = null;
				}
			}
		}
	}
