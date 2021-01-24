    using ZXing;
    using ZXing.Client.Result;
    using ZXing.Common;
    using ZXing.QrCode;
    
    var QRreader= new ZXing.QrCode.QRCodeReader();
    var barcodeBitmap = (Bitmap)Bitmap.FromFile(filePath);
    var result = QRreader.decode(barcodeBitmap);
    if (result != null)
    {
       Debug.Log(result.Text);
    }
