    using System.Collections;
    using System.Collections.Generic;
    using GoogleMobileAds;
    using GoogleMobileAds.Api;
    using UnityEngine;
    
    public class BannerAd : MonoBehaviour
    {
    
        private BannerView bannerView;
    
        // Use this for initialization
        void Start ()
        {
            string appID = "ca-app-pub-id"; // this is appId
    
            MobileAds.Initialize (appID);
    
            string adUnitId = "ca-app-pub-adUnitId"; // adUnitID
    
            this.showBannerAd (adUnitId);
        }
    
        private void showBannerAd (string adUnitId)
        {
    
            //Create a custom ad size at the bottom of the screen
    
            AdSize adSize = new AdSize (250, 50);
            bannerView = new BannerView (adUnitId, adSize, AdPosition.Bottom);
    
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder ().Build ();
    
            // Load the banner with the request.
            bannerView.LoadAd (request);
    
        }
    
        
    }
