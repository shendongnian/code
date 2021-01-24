    public partial class MyContentPage : ContentPage
    {
        ...
    
        void ResizeFooterWrapper(double heightRequest)
        {
            Device.BeginInvokeOnMainThread(() => 
            {
                FooterWrapper.HeightRequest = heightRequest;
                FooterWrapper.ForceLayout();
                this.ForceLayout();
            }
        }
    }
