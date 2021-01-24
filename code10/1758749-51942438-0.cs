    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Windows;
    using DevExpress.BarCodes;
    
    namespace WpfBarcode01
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
    
        public MainWindow()
        {
          InitializeComponent();
        }
    
        private void Btn_1_Click(object sender, RoutedEventArgs e)
        {
        BarCode barCode = new BarCode();
          barCode.Symbology = Symbology.QRCode;
          barCode.CodeText = 
          "Alexander Johnathon Stevenson JR;Senior Software Developer;alexanderjohnathonstevensonjr@somesamplewebsite.com;20180709-08:00:00;9993334444;Los Angeles;CA;USA;ABC Company";
          barCode.BackColor = Color.White;
          barCode.ForeColor = Color.Black;
          barCode.RotationAngle = 0;
          barCode.CodeBinaryData = Encoding.Default.GetBytes(barCode.CodeText);
          barCode.Options.QRCode.Version = QRCodeVersion.Version5;
          barCode.Options.QRCode.CompactionMode = QRCodeCompactionMode.Byte;
          barCode.Options.QRCode.ErrorLevel = QRCodeErrorLevel.H;
          barCode.Options.QRCode.ShowCodeText = false;
          barCode.Dpi = 200;
          barCode.AutoSize = false; //needs to be off if specifying unit and widths
          barCode.Unit = GraphicsUnit.Millimeter;  // Note: 1 inch = 25.4 Millimeters    
          barCode.ImageWidth = 70F;
          barCode.ImageHeight = 70F;
    
          Bitmap bitmap = ResizeImage(barCode.BarCodeImage, 200, 200);
    
          bitmap.Save("QRCode.png");
    
          Process.Start("QRCode.png");
        }
    
    
        public static Bitmap ResizeImage(Image originalImage, int newWidthInPixels, int newHeightInPixels)
        {
          var destRect  = new Rectangle(0, 0, newWidthInPixels, newHeightInPixels);
          var destImage = new Bitmap(newWidthInPixels, newHeightInPixels);
    
          destImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
    
          using (var graphics = Graphics.FromImage(destImage))
          {
            graphics.CompositingMode    = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode  = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode      = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode    = PixelOffsetMode.HighQuality;
    
            using (var wrapMode = new ImageAttributes())
            {
              wrapMode.SetWrapMode(WrapMode.TileFlipXY);
              graphics.DrawImage(originalImage, destRect, 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, wrapMode);
            }
          }
    
          return destImage;
        }
      }
    }
