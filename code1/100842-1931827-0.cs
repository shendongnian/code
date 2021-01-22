    [Table]
    public partial class sp_rpt_wcfResult
    {
        public byte[] OrderNumLabel {
            get {
                return
                    BarcodeUtilities.ConvertImageToByteArray(
                      BarcodeUtilities.GetBarcodeImage(this.order_number.ToString()),
                      System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
        ....
