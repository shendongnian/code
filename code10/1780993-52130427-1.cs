    public class InterstitialAdListener : AdListener
    {
        readonly InterstitialAd _ad;
        public InterstitialAdListener(InterstitialAd ad)
        {
            _ad = ad;
        }
        public override void OnAdLoaded()
        {
            base.OnAdLoaded();
            //if (_ad.IsLoaded)
            //    _ad.Show();
        }
    }
    public class AdmobInterstitial : Controls.IAdmobInterstitial
    {
        InterstitialAd _ad;
        public void Show(string adUnit)
        {
            var context = Android.App.Application.Context;
            _ad = new InterstitialAd(context);
            _ad.AdUnitId = adUnit;
            var intlistener = new InterstitialAdListener(_ad);
            intlistener.OnAdLoaded();
            _ad.AdListener = intlistener;
            
            var requestbuilder = new AdRequest.Builder().AddTestDevice("302E90D530B2193F59FDD7F22A11B45A");
            _ad.LoadAd(requestbuilder.Build());
        }
        public void Give()
        {
            if (_ad.IsLoaded)
                _ad.Show();
        }
    }
