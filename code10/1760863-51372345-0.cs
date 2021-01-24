    public class EnemyMovement : MonoBehaviour
    {
        public enum MovementType
        {
            None = 0,
            Linear = 1,
            Sinusoidal = 2
            // etc, etcc
        }
    
        /// <summary>
        /// Movement affects the movement type of the enemy.
        /// </summary>
        public MovementType Movement { get; set; }
    
        /// <summary>
        /// This affects the Speed of the Enemy. Used in conunction with Movement to
        /// produce the enenmy's wave movement type.
        /// </summary>
        public float Speed { get; set; }
    
        private Rigidbody rigidBody;
    
    
        private void Awake ( )
        {
            rigidBody = GetComponent<Rigidbody> ( );
        }
    
    
        private void Update ( )
        {
            switch ( Movement)
            {
                case MovementType.Linear:
                    transform.Translate ( Vector3.forward * Speed * Time.deltaTime );
                    break;
                case MovementType.Sinusoidal:
                    // You probably want the Speed property to affect this as well...
                    rigidBody.velocity = Vector3.forward * 5 + Vector3.left * 3 * Mathf.Sin ( 10f * Time.time );
                    break;
    
               // Any extra movement types you want here...
            }
    
        }
    }
