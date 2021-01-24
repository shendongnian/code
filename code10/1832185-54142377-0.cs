    public class AdManager{
       public static AdManager instance;
    
       private void Awake(){
           if(instance == null) {
             instance = this;
             DontDestroyOnLoad(gameObject);
           } else {
             Destroy(gameObject);
             return;
           }
       }
       private void Start()
       {
        
           #if UNITY_ANDROID
              string appId = "ca-app-pub-3940256099942544/1033173712";
           #else
              string appId = "unexpected_platform";
           #endif
           // Initialize the Google Mobile Ads SDK.
           MobileAds.Initialize(appId);
           this.RequestInterstitial();
       }
        public void showInterstitial(){
          if ((loadCount % 3) == 0)  // only show ad every third time
          {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
         }
        
    }
