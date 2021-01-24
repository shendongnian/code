	public class PlayerMover : MonoBehaviour
	{
		/// Movement speed units per second
		[SerializeField]
		private float speed;
		
        /// X coordinate of the initial press
        // The '?' makes the float nullable
		private float? pressX;
		
		
		
        /// Called once every frame
		private void Update()
		{
			// If pressed with one finger
			if(Input.GetMouseButtonDown(0))
				pressX = Input.touches[0].position.x;
			else if (Input.GetMouseButtonUp(0))
				pressX = null;
				
			
			if(pressX != null)
			{
				float currentX = Input.touches[0].position.x;
                // The finger of initial press is now left of the press position
				if(currentX < pressX)
					Move(-speed);
                // The finger of initial press is now right of the press position
				else if(currentX > pressX)
					Move(speed);
                // else is not required as if you manage (somehow)
                // move you finger back to initial X coordinate
                // you should just be staying still
			}
		}
		
		
		`
		/// Moves the player
		private void Move(float velocity)
		{
			transform.position += Vector3.right * velocity * Time.deltaTime;
		}
		
	}
