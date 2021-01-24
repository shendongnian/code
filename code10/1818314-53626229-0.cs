    using Android.Gms.Ads;
    using Android.Gms.Ads.Reward;
    using Xamarin.Forms;
    using Android.Views;
    using AdsGoogle;
    using Android.Widget;
    using System;
    using System.Timers;
    using Android.OS;
    using Android.Support.V7.App;
    [assembly: Dependency(typeof(AdsGoogle.Droid.AdInterstitial_Droid))]
    namespace AdsGoogle.Droid
    {
        public class AdInterstitial_Droid : AppCompatActivity, IRewardedVideoAdListener, IAdInterstitial
        {
            public IRewardedVideoAd RewardedVideoAd;
            public AdInterstitial_Droid()
            {
                RewardedVideoAd = MobileAds.GetRewardedVideoAdInstance(Android.App.Application.Context);
                RewardedVideoAd.RewardedVideoAdListener = this;
                //RewardedVideoAd.AdUnitId = "ca-app-pub-2667741859949498/7232000911";
                LoadAd();
            }
            void LoadAd()
            {
                var requestbuilder = new AdRequest.Builder();
                RewardedVideoAd.LoadAd("ca-app-pub-2667741859949498/7232000911", requestbuilder.Build());
            }
            public void ShowRewardedVideo()
            {
                if (RewardedVideoAd.IsLoaded)
                {
                    RewardedVideoAd.Show();
                    //Toast.MakeText(Android.App.Application.Context, MainPage.AdCoins.ToString(), ToastLength.Long).Show();
                }
                LoadAd();
            }
            
            
