    public class EnemySpawner : MonoBehaviour
    {
        public float Delay;
        public float StartSpeed;
    
        public GameObject enemy;
        public GameObject enemySpawner;
        public Vector3 offset;
    
        private float timeElapsed;
        private float currentSpeed;
        private EnemyMovement.MovementType currentMovement;
    
    
        void Start ( )
        {
            timeElapsed = 0f;
            currentSpeed = StartSpeed;
            StartCoroutine ( SpawnEnemies ( Delay ) );
            currentMovement = EnemyMovement.MovementType.Linear;
        }
    
    
        void Update ( )
        {
            timeElapsed += Time.deltaTime;
            // We can determine at what time the Wave parameters change here.
            if ( timeElapsed >= 40.0f )
            {
                currentSpeed += 10.0f; // Add speed, for example.
            }
            else if ( timeElapsed >= 20.0f )
            {
                currentMovement = EnemyMovement.MovementType.Sinusoidal;
            }
        }
    
    
        IEnumerator SpawnEnemies ( float delay )
        {
            while ( true )
            {
                var enemyClone = Instantiate ( enemy, enemySpawner.transform.position + offset, Quaternion.identity );
                var movement = enemyClone.GetComponent<EnemyMovement> ( );
                // We now set what the enemy uses as the Wave values.
                movement.Speed = currentSpeed;
                movement.Movement = currentMovement;
    
                yield return new WaitForSeconds ( delay );
            }
        }
    }
