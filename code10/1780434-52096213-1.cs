    public class ObjectRelativeScale : MonoBehaviour
    {
        public float ObjectScale = 1.0f;
        private Vector3 _initialScale;
    void Start()
    {
        _initialScale = transform.localScale;
    }
    void Update()
    {
        var cameraMainTransform = Camera.main.transform;
        var plane = new Plane(cameraMainTransform.forward, cameraMainTransform.position);
        float dist = plane.GetDistanceToPoint(transform.position);
        transform.localScale = _initialScale * dist * ObjectScale;
    }
