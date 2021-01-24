    public class Box : MonoBehaviour
    {
        private Bounds _initialUnrotatedBounds;
    
        private void Awake()
        {
            InitializeUnrotatedBounds();
        }
    
        private void InitializeUnrotatedBounds()
        {
            Assert.IsTrue(transform.rotation == Quaternion.identity);
    
            _initialUnrotatedBounds = GetComponent<MeshRenderer>().bounds;
        }
    
        private void Update()
        {
            // Use the cached bounds. Now, even for moving objects,
            // it doesn't matter if the rotation changes
            float height = _initialUnrotatedBounds.size.y;
            Debug.Log(height);
        }
    }
