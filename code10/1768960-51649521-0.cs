    [assembly: Dependency(typeof(BarcodeScanner))]
    namespace CodeMashScanner.Droid.Helpers
    {
        public class BarcodeScanner : IBarcodeScanner
        {
            public async Task<string> ScanAsync()
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner(Forms.Context;
                var scanResults = await scanner.Scan();
    
                return scanResults.Text;
            }
        }
    }
