	public class Character : MonoBehaviour {
		bool ignore = false;
		int layerCube = 0;
		int layerRoof = 8;
		
		void Update () {
			if (Input.GetKeyDown(KeyCode.Space))
				GetComponent<Rigidbody>().AddForce(Vector3.up * 8,ForceMode.Impulse);
			if (Input.GetKeyDown(KeyCode.S)) {
				ignore = !ignore;
				Physics.IgnoreLayerCollision(layerCube, layerRoof, ignore);
			}
		}
	}
