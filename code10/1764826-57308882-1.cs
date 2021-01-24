    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(EdgeCollider2D))]
    [RequireComponent(typeof(Image))]
    public class Circlesegment : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] EdgeCollider2D collider;
        [SerializeField] Rigidbody2D rigidBody;
        [SerializeField] RectTransform rectTransform;
    
        [SerializeField] private int _segments;
        [SerializeField] private float _startAngle;
        [SerializeField] private float _segmentAngle;
    
        private float _radius;
        private CircleController circleController;
    
        public Color Color;
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            circleController.RemoveSegment(this);
        }
    
        public void Initialize(CircleController controller, Color color, int segments, float radius, float startAngle, float segmentAngle)
        {
            Color = color;
            circleController = controller;
            _radius = radius;
    
            if (!image) image = GetComponent<Image>();
            if (!collider) collider = GetComponent<EdgeCollider2D>();
            if (!rigidBody) rigidBody = GetComponent<Rigidbody2D>();
            if (!rectTransform) rectTransform = GetComponent<RectTransform>();
    
            image.color = color;
            rectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
    
            UpdateSegment(segments, startAngle, segmentAngle);
        }
    
        public void AnimateTowards(int segments, float startAngle, float segmentAngle, float duration = 1f)
        {
            StopAllCoroutines();
    
            StartCoroutine(AnimateTowardsroutine(segments, startAngle, segmentAngle, duration));
        }
    
        private IEnumerator AnimateTowardsroutine(int segments, float startAngle, float segmentAngle, float duration)
        {
            var timePassed = 0f;
            var currentStartAngle = _startAngle;
            var currentSegmentAngle = _segmentAngle;
    
            while (timePassed <= duration)
            {
                var lerpFactor = timePassed / duration;
    
                UpdateSegment(segments, Mathf.LerpAngle(currentStartAngle, startAngle, lerpFactor), Mathf.LerpAngle(currentSegmentAngle, segmentAngle, lerpFactor));
    
                timePassed += Mathf.Min(duration - timePassed, Time.deltaTime);
                yield return null;
            }
    
            UpdateSegment(segments, startAngle, segmentAngle);
        }
    
        public void UpdateSegment(int segments, float startAngle, float segmentAngle)
        {
            _segments = segments;
            _startAngle = startAngle;
            _segmentAngle = segmentAngle;
    
            var arcPoints = new List<Vector2>();
            var angle = 0f;
            var arcLength = segmentAngle;
    
            if (!Mathf.Approximately(Mathf.Abs(segmentAngle), 360)) arcPoints.Add(Vector2.zero);
    
            // calculate procedural circle vertices
            for (var i = 0; i <= segments; i++)
            {
                var x = Mathf.Sin(Mathf.Deg2Rad * angle) * _radius;
                var y = Mathf.Cos(Mathf.Deg2Rad * angle) * _radius;
    
                arcPoints.Add(new Vector2(x, y));
    
                angle += (arcLength / segments);
            }
    
            if (!Mathf.Approximately(Mathf.Abs(segmentAngle), 360)) arcPoints.Add(Vector2.zero);
    
            image.fillAmount = arcLength / 360f;
            rigidBody.rotation = startAngle;
            collider.points = arcPoints.ToArray();
        }
    
        // For testing
        [ContextMenu("UpdateSegment")]
        private void UpdateSegment()
        {
            UpdateSegment(_segments, _startAngle, _segmentAngle);
        }
    
        //For testing
        [ContextMenu("AnimateTowards")]
        private void AnimateTowards()
        {
            AnimateTowards(_segments, _startAngle, _segmentAngle);
        }
    }
    
