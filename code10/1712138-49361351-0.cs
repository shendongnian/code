    using UnityEngine;
    
    public class PingPong : MonoBehaviour {
        public float k = 0f;
        public Vector3 WayPointA = new Vector3(100, 0, 100);
        public Vector3 WayPointB = new Vector3(0, 0, 0);
        void Update() {
            k = Mathf.PingPong(Time.time, 1);
            transform.position = Vector3.Lerp(WayPointA, WayPointB, k);
        }
    }
