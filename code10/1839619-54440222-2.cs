    using GoogleMobileAds.Api;
    ...
    public class GoogleMobileAdsDemoScript : MonoBehaviour
    {
        private RewardBasedVideoAd rewardBasedVideo;
        ...
    
        public void Start()
        {
            // Get singleton reward based video ad reference.
            this.rewardBasedVideo = RewardBasedVideoAd.Instance;
    
            // Called when an ad request has successfully loaded.
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
            // Called when an ad request failed to load.
            rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
    
            this.RequestRewardBasedVideo();
        }
    
        private void RequestRewardBasedVideo()
        {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/5224354917";
            #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/1712485313";
            #else
                string adUnitId = "unexpected_platform";
            #endif
    
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded video ad with the request.
            this.rewardBasedVideo.LoadAd(request, adUnitId);
        }
    
        public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
        }
    
        public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            MonoBehaviour.print(
                "HandleRewardBasedVideoFailedToLoad event received with message: "
                                 + args.Message);
        }
