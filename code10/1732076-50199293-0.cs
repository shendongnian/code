    using UnityEngine;
    using System.Collections;
    using GoogleMobileAds.Api;
    
    public class AdmobScript : MonoBehaviour
    {
    
        private string BannerId;
    
    
        // Use this for initialization
        void Awake()
        {
            //Request Ads
            RequestBanner();
    
        }
    
        private void RequestBanner()
        {
    #if UNITY_EDITOR
            string adUnitId = "unused";
    #elif UNITY_ANDROID
    		string adUnitId = "You UNIT-ID HERE";
    #elif UNITY_IPHONE
    			string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
    #else
    			string adUnitId = "unexpected_platform";
    #endif
    
            // Create a 320x50 banner at the bottom of the screen.
            BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the banner with the request.
            bannerView.LoadAd(request);
        }
    }
