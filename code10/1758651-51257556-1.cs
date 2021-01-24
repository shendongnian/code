    class MyGridView : GridView
    {
        private const string ImageStation = "ImageStation";
        private const string StationName = "StationName";
        private const string RootLayout = "RootLayout";
        private bool isFirst;
    
        NativeAdsManagerV2 myNativeAdsManager = null;
        string myAppId = "d25517cb-12d4-4699-8bdc-52040c712cab";
        string myAdUnitId = "test";
    
        public MyGridView()
        {
            myNativeAdsManager = new NativeAdsManagerV2(myAppId, myAdUnitId);
            myNativeAdsManager.AdReady += MyNativeAd_AdReady;
            myNativeAdsManager.ErrorOccurred += MyNativeAdsManager_ErrorOccurred;
            myNativeAdsManager.RequestAd();
        }
    
        private void MyNativeAdsManager_ErrorOccurred(object sender, NativeAdErrorEventArgs e)
        {
    
        }
    
        private void MyNativeAd_AdReady(object sender, NativeAdReadyEventArgs e)
        {
            NativeAdV2 nativeAd = e.NativeAd;
            AdTitle.Text = nativeAd.Title;
            Adimage.Source = nativeAd.AdIcon.Source;
            nativeAd.RegisterAdContainer(AdContainer);
        }
    
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if (this.IndexFromContainer(element) == 0)
            {
                isFirst = true;
            }
            else
            {
                isFirst = false;
            }
    
            base.PrepareContainerForItemOverride(element, item);
        }
    
    
        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
    
        }
        private Image Adimage;
        private TextBlock AdTitle;
        private Grid AdContainer;
    
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (isFirst)
            {
                var item = this.ContainerFromIndex(0);
                AdContainer = MyFindGridViewChildByName(item, RootLayout) as Grid;
                Adimage = MyFindGridViewChildByName(item, ImageStation) as Image;
                AdTitle = MyFindGridViewChildByName(item, StationName) as TextBlock;
                isFirst = false;
    
            }
    
            return base.ArrangeOverride(finalSize);
        }
    
        public static DependencyObject MyFindGridViewChildByName(DependencyObject parant, string ControlName)
        {
            int count = VisualTreeHelper.GetChildrenCount(parant);
    
            for (int i = 0; i < count; i++)
            {
                var MyChild = VisualTreeHelper.GetChild(parant, i);
                if (MyChild is FrameworkElement && ((FrameworkElement)MyChild).Name == ControlName)
                    return MyChild;
    
                var FindResult = MyFindGridViewChildByName(MyChild, ControlName);
                if (FindResult != null)
                    return FindResult;
            }
    
            return null;
        }
    
    }
