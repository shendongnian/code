    public class WaterHose : MonoBehaviour {
	private void OnParticleCollision(GameObject other)
	{
		Collider col = other.GetComponent<Collider>();
		if (col is CapsuleCollider)
			Debug.Log("We hit the player!");
		else if (col is BoxCollider)
			Debug.Log("We hit the umbrella!");
	}
    }
