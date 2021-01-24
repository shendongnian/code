    public class ARTrackingStatusController : MonoBehaviour {
    
    	//1. Get Reference To The Session
    	private UnityARSessionNativeInterface augmentedRealitySession;
    
    
    	private string arTrackingStatus = "Preparing Device...";
    
    
    	//------------------
    	//MARK: -  LifeCycle
    	//------------------
    
    	void Start () {
    
    		//1. Register For The ARFrame Updated Event Which In IOS = (func renderer(_ renderer: SCNSceneRenderer, updateAtTime time: TimeInterval))
    		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
    		UnityARSessionNativeInterface.ARSessionFailedEvent += ARSessionFailedEvent;
    
    
    	}
    
    	void Update () {
    
    		//1. Update The Status Of The Session
    		print(arTrackingStatus);
    	
    	}
    
    
    	//-------------------------
    	//MARK: - ARSCNViewDelegate
    	//-------------------------
    
    	/// <summary>
    	/// Called Each Time The ARCamera Is Updated
    	/// </summary>
    	/// <param name="camera">Camera.</param>
    	public void ARFrameUpdated (UnityARCamera camera)
    	{
    
    		//1. Track The ARSession
    		if (camera.trackingState == ARTrackingState.ARTrackingStateLimited) {
    
    			logTrackingStateReason (camera.trackingReason);
    
    		} else {
    
    			logTrackingState (camera.trackingState);
    
    		}
    
    		logLighting (camera.lightData.arLightEstimate.ambientIntensity);
    
    	}
    
    	/// <summary>
    	/// Logs The ARSession Failed Event
    	/// </summary>
    	/// <param name="error">Error.</param>
    	public void ARSessionFailedEvent (string error)
    	{
    
    		print (error);
    
    	}
    		
    	//----------------------
    	//MARK: - Status Updates
    	//----------------------
    
    	/// <summary>
    	/// Informs The User About The Current Tracking State
    	/// </summary>
    	/// <param name="trackingState">Tracking state.</param>
    	public void logTrackingState (ARTrackingState trackingState)
    	{
    
    		switch (trackingState) {
    
    		case ARTrackingState.ARTrackingStateNormal:
    			arTrackingStatus = "Tracking Ready";
    
    			break;
    
    		case ARTrackingState.ARTrackingStateNotAvailable:
    			arTrackingStatus = "Tracking Unavailable";
    			break;
    
    		}
    			
    
    	}
    
    	/// <summary>
    	/// Informs The User About The Current Tracking Status
    	/// </summary>
    	/// <param name="reason">Reason.</param>
    	public void logTrackingStateReason (ARTrackingStateReason reason)
    	{
    
    		switch (reason) {
    
    		case ARTrackingStateReason.ARTrackingStateReasonExcessiveMotion:
    			arTrackingStatus = "Please Slow Your Movement";
    			break;
    
    		case ARTrackingStateReason.ARTrackingStateReasonInsufficientFeatures:
    			arTrackingStatus = "Try To Point At A Flat Surface";
    			break;
    
    		case ARTrackingStateReason.ARTrackingStateReasonInitializing:
    			arTrackingStatus = "Initializing";
    			break;
    
    		case ARTrackingStateReason.ARTrackingStateReasonRelocalizing:
    			arTrackingStatus = "Relocalizing";
    			break;
    
    		case ARTrackingStateReason.ARTrackingStateReasonNone:
    			arTrackingStatus = "";
    			break;
    
    		}
    
    	
    	}
    
    	/// <summary>
    	/// Determines If The Current Lighting Conditions Are Appropriate For The ARSession
    	/// </summary>
    	/// <param name="lightEstimate">Light estimate.</param>
    	public void logLighting (float lightEstimate)
    	{
    
    		if (lightEstimate < 100) {
    			arTrackingStatus = "Lighting Is To Dark";
    
    		}
    
    	}
    		
