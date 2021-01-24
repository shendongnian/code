	public class PlayerMover : MonoBehaviour
	{
		/// Movement speed units per second
		[SerializeField]
		private float speed;
		
        /// Starting position of the press
        // The '?' makes Vector2 nullable
		private Vector2? pressPosition;
		
		
		
        /// Called once every frame
		private void Update()
		{
			// If pressed with one finger
			if(Input.GetMouseButtonDown(0))
				pressPosition = Input.touches[0].position;
			else if (Input.GetMouseButtonUp(0))
				pressPosition = null;
				
			
			if(pressPosition != null)
			{
				Vector2 currentPosition = Input.touches[0].position;
				if(currentPosition.x < pressPosition.x)
					Move(-speed);	// Define this method
				else
					Move(speed);
			}
		}
		
		
		`
		/// Moves the player
		private void Move(float velocity)
		{
			transform.position += Vector3.right * velocity * Time.deltaTime;
		}
		
	}
