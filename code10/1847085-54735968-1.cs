    public Vector3 rotation;
    private GameObject go;
    private void Start()
    {
        go = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
    void Update()
    {
        go.transform.rotation = Quaternion.Euler(Mathf.Clamp(rotation.x, 0, 90), 
        rotation.y, rotation.z);
    }
---
    public class CameraClamp : MonoBehaviour
    {
        public float speed;
        public Vector2 clamp; // x = min, y = max
        private float pitch;
        private void Update()
        {
            pitch += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, clamp.x, clamp.y);
        }
        private void LateUpdate()
        {
            gameObject.transform.rotation = Quaternion.Euler(pitch, 0, 0);
        }
    }
