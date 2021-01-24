        private ZXingBarcodeImageView barcode=null;
        public MainPage()
        {
            InitializeComponent();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (barcode==null){
                barcode = new ZXingBarcodeImageView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };
                barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_128;
                barcode.BarcodeOptions.Width = 500;
                barcode.BarcodeOptions.Height = 100;
                barcode.BarcodeValue = contentEntry.Text.Trim();
                barResult.Content = barcode;
            }else{
                barcode.BarcodeValue = contentEntry.Text.Trim();
            }
                
        }
