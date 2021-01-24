	private void OnCollisionStay(Collision other)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			other.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
	}
