    public class CustomContentPositioningBehaviour : MonoBehaviour
    {
		public GameObject yourContentPrefab;
		
		private PositionalDeviceTracker deviceTracker;
		private GameObject previousAnchor;
		public void Awake()
		{
			VuforiaARController.Instance.RegisterVuforiaStartedCallback( OnVuforiaStarted );
		}
		public void OnDestroy()
		{
			VuforiaARController.Instance.UnregisterVuforiaStartedCallback( OnVuforiaStarted );
		}
		private void OnVuforiaStarted()
		{
			deviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
		}
		public void SpawnContent( HitTestResult result )
		{
			if( result == null || yourContentPrefab == null)
			{
				Debug.LogWarning( "Hit test is invalid or content is not set" );
				return;
			}
			var anchor = deviceTracker.CreatePlaneAnchor( Guid.NewGuid().ToString(), result );
			if( anchor != null )
			{
				anchor.transform.parent = this.gameObject.transform;
				GameObject content = Instantiate( yourContentPrefab );
			
				content.transform.parent = anchor.transform;
				content.transform.localPosition = Vector3.zero;
				content.transform.localRotation = Quaternion.identity;
				content.SetActive( true );
			}
			if( previousAnchor != null )
			{
				Destroy( previousAnchor );
			}
			previousAnchor = anchor;
		}
     }
