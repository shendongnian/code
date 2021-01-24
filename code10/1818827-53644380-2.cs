        private const float threshold = 0.02f;
        private Vector3 startingPos;
        private Vector3 destinationPos;
        private Vector3 velocity;
        public float radius = 0.1f;
        public float minTimeDelay = 0.1f;
        public float maxTimeDelay = 0.3f;
        private void Start() {
            startingPos = destinationPos = transform.position;
        }
        // This is a 'physics' frame update
        public void FixedUpdate() {
            if ( Vector3.Distance(transform.position, destinationPos) < threshold ) {
                // Pick new destination and speed
                destinationPos = startingPos + Random.insideUnitSphere * radius;
                velocity = (destinationPos - transform.position) / Random.Range(minTimeDelay, maxTimeDelay);
            }
            // Move toward destination
            transform.position += velocity * Time.fixedDeltaTime;
        }
