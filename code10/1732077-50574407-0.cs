    using System.Collections;
    using UnityEngine;
    using GoogleMobileAds.Api;
    public class AdInitializer : MonoBehaviour {
	    public void Start()
	    {
		    #if UNITY_ANDROID
		    string appId = "ca-app-pub-XXXXXXXXXXXXXXXX~XXXXXXXXXX";
		    #elif UNITY_IPHONE
		    string appId = "ca-app-pub-XXXXXXXXXXXXXXXX~XXXXXXXXXX";
		    #else
            string appId = "unexpected_platform";
            #endif
    		// Initialize the Google Mobile Ads SDK.
    		MobileAds.Initialize(appId);
    		Debug.Log ("Initializing ads for app ID " + appId);
    	}
    }
