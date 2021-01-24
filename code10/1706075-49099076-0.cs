    using Android.Gms.Ads;
    
    ...
    
    var adView = new AdView(Context);
    adView.AdUnitId = "ca-app-pub-3756076456456456/1111123234/app320x250";
    adView.AdSize = new AdSize(300, 250);
    
    // do whatever with adView, add as child, set as native control (if using ViewRenderers etc)
    // OR
    
    var interstitialAd = new InterstitialAd(Context);
    interstitialAd.AdUnitId = "ca-app-pub-434343434/34343434/myinterstitial";
    
    var requestbuilder = new AdRequest.Builder();
    interstitialAd.LoadAd(requestbuilder.Build());
    interstitialAd.Show();
