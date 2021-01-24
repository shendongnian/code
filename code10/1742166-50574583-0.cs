	public class SushiHangoverTextEventBanner : Java.Lang.Object, ICustomEventBanner
	{
		SushiHangoverTextAdView customAdView;
		public void OnDestroy()
		{
			customAdView?.Dispose();
		}
		public void OnPause()
		{
            ~~~
		}
		public void OnResume()
		{
            ~~~
		}
		public void RequestBannerAd(Context context, ICustomEventBannerListener listener, string serverParameter, AdSize size, IMediationAdRequest mediationAdRequest, Bundle customEventExtras)
		{
			customAdView = new SushiHangoverTextAdView(context);
            ~~~
        }
    }
