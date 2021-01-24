    public class CircleController : MonoBehaviour
    {
        public RectTransform rectTransform;
    
        public List<Color> InitialColors = new List<Color>();
    
    
        private List<Circlesegment> segments = new List<Circlesegment>();
    
        public Circlesegment circleSeggmentPrefab;
    
        public float firstSegmentAngleOffset = 0f;
    
        // maximum vertices to use for the circle
        // equally spread over all segments so not always uses all of them
        public int totalMaxVertices = 50;
    
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
    
            // if 0 start first segment at top
            var startAngle = firstSegmentAngleOffset;
            var anglePerSegment = 360f / InitialColors.Count;
            var verticesPerSegment = totalMaxVertices / InitialColors.Count;
    
            foreach (var initialColor in InitialColors)
            {
                var segment = Instantiate(circleSeggmentPrefab, transform);
                segment.Initialize(this, initialColor, verticesPerSegment, rectTransform.rect.width / 2f, startAngle, anglePerSegment);
    
                segments.Add(segment);
    
                startAngle += anglePerSegment;
            }
        }
    
        // Used this to simulate the collisions using the mouse
        private CircleCollider2D cursor;
    
        //used this to simulate the collision using mouse
        private void Update()
        {
            if (!cursor)
            {
                cursor = new GameObject("cursor simulator", typeof(CircleCollider2D)).GetComponent<CircleCollider2D>();
                cursor.radius = 10;
                cursor.enabled = false;
            }
    
            cursor.transform.position = Input.mousePosition;
    
            if (Input.GetMouseButtonDown(0))
            {
                cursor.enabled = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                cursor.enabled = false;
            }
        }
    
        public void RemoveSegment(Circlesegment segment)
        {
            segments.Remove(segment);
            Destroy(segment.gameObject);
    
            if (segments.Count == 0)
            {
                Debug.Log("GameOver!");
                return;
            }
    
            var startAngle = firstSegmentAngleOffset;
            var anglePerSegment = 360f / segments.Count;
            var verticesPerSegment = totalMaxVertices / segments.Count;
    
            foreach (var circleSegment in segments)
            {
                circleSegment.AnimateTowards(verticesPerSegment, startAngle, anglePerSegment);
    
                startAngle += anglePerSegment;
            }
        }
    }
    
