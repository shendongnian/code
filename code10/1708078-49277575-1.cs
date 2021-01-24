    public partial class Page : ContentPage
    {
        
        public Page()
        {
            InitializeComponent();
           
         
            var isDeviceIphone = DependencyService.Get<IDeviceInfo>().IsIphoneXDevice();
            if (isDeviceIphone)
            {
                var safeInsets = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
                safeInsets.Bottom =20;
                safeInsets.Top = 20;
                this.Padding = safeInsets;
            }
        }
 
    }
