    using UnityEngine;
    using UnityEngine.AI;
    
    [RequireComponent (typeof (NavMeshAgent))]
    [RequireComponent (typeof (Animator))]
    public class LocomotionSimpleAgent : MonoBehaviour {
    	
        private const float SmoothingCoefficient = .15f;
    
        [SerializeField] private float _velocityDenominatorMultiplier = .5f;
        [SerializeField] private float _minVelx = -2.240229f;
        [SerializeField] private float _maxVelx = 2.205063f;
        [SerializeField] private float _minVely = -2.33254f;
        [SerializeField] private float _maxVely = 3.70712f;
    
        public Vector3 Goal {
            get { return _agent.destination; }
            set {
                _agent.destination = value;
                _smoothDeltaPosition = Vector2.zero;
            }
        }
    
        private NavMeshAgent _agent;
        private Animator _animator;
        private Vector2 _smoothDeltaPosition;
    
        public void Start() {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.updatePosition = false;
            _smoothDeltaPosition = default(Vector2);
            Goal = transform.position;
        }
    
        public void FixedUpdate() {
            var worldDeltaPosition = _agent.nextPosition - transform.position;
            var dx = Vector3.Dot(transform.right, worldDeltaPosition);
            var dy = Vector3.Dot(transform.forward, worldDeltaPosition);
            var deltaPosition = new Vector2(dx, dy);
            var smooth = Time.fixedDeltaTime / SmoothingCoefficient;
    
            _smoothDeltaPosition = Vector2.Lerp(_smoothDeltaPosition, deltaPosition, smooth);
    
            var velocity = _smoothDeltaPosition / (Time.fixedDeltaTime * _velocityDenominatorMultiplier);
            var shouldMove = _agent.remainingDistance > .1f;
            var x = Mathf.Clamp(Mathf.Round(velocity.x * 1000) / 1000, _minVelx, _maxVelx);
            var y = Mathf.Clamp(Mathf.Round(velocity.y * 1000) / 1000, _minVely, _maxVely);
    
            _animator.SetBool("move", shouldMove);
            _animator.SetFloat("velx", x);
            _animator.SetFloat("vely", y);
    
            if (worldDeltaPosition.magnitude > _agent.radius / 16 && shouldMove) {
                _agent.nextPosition = transform.position + 0.1f * worldDeltaPosition;
            }
        }
    
        public void OnAnimatorMove() {
            var position = _animator.rootPosition;
    
            position.y = _agent.nextPosition.y;
            transform.position = position;
        }
    }
