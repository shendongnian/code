	public class ChasePlayer : MonoBehaviour
	{
		public Light playerLight;
		public float speed;
		public Transform target;
		
		private void FollowLight()
		{
			// Does checking for given statement but is only executed in Debug mode.
			// Fairly good for fail-proofing private methods
			// Or clarifying, what values should be before invoking the method.
			Debug.Assert(playerLight != null);
			
			float walkspeed = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, walkspeed);      
		}
		private void Update()
		{
			if(playerLight != null && playerLight.enabled)
				FollowLight();
		}
	}
