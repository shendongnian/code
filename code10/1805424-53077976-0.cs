    private void LateUpdate()
	{
		if (!player.isMoving)
		{
			// snap the rotation center slowly to the player's position
            // you can modify this to respect some constraint, like for example taking a certain amount of time
			rotationCenter = Vector3.Lerp(rotationCenter, player.transform.position, 0.1f);
        }
        // rotate around rotation center
		Quaternion camTurnAngle = Quaternion.AngleAxis(rotationSpeed * Time.time, Vector3.up);      
		rotationCenter += camTurnAngle * offset;
        // set the position to rotate around rotation center, and look towards player
		transform.position = Vector3.Lerp(transform.position, rotationCenter, smoothFactor);
		transform.LookAt(player.transform);
    }
