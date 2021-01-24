    [ExecuteInEditMode]
    public class SlopeAngleHelper : MonoBehaviour {
        public float MaxSlopeAngle;
        public Transform RayOrigin;
	    void Update () 
        {
            Vector3 direction = Quaternion.Euler(-MaxSlopeAngle, 0, 0) * transform.forward;
            Debug.DrawRay(RayOrigin.position, transform.forward, Color.black, 0.01f, false);
            Debug.DrawRay(RayOrigin.position, direction, Color.red, 0.01f, false);
        }
    }
