    public class WaterHose : MonoBehaviour {
	private void OnParticleCollision(GameObject other)
	{
		//Get the component specifically in the gameobject we hit
		//This by default ignores parents/children.
		Health health = other.GetComponent<Health>();
		if (health != null)
			health.Damage(5);
	}
    }
