    public class Spawner : MonoBehaviour {
        public Enemy enemyPrefab;
        public List<Enemy> enemyPool;
        public const SPAWN_HEIGHT = 0.75f;
        // Start is called before the first frame update
        void Start()
        {
            enemyPool = new List<Enemy>();
            spawnEnemy();
        }
        // Update is called once per frame
        public void Despawn(Enemy deadEnemy)
        {
            deadEnemy.gameObject.SetActive(false);
            enemyPool.Add(deadEnemy);
        }
        public void spawnEnemy() {
            Enemy newEnemy;
            if (enemyPool.Count > 0) {
                newEnemy = enemyPool[0];
                enemyPool.Remove(0);
            } else {
                newEnemy = Instantiate(enemyPrefab);
            }
            newEnemy.Init(this);
            newEnemy.position =  new Vector3(Random.Range(-5, 5), SPAWN_HEIGHT, Random.Range(-5, 5));
            newEnemy.gameObject.SetActive(true);
        }
    }
    public class Enemy : MonoBehaviour {
        private Spawner spawner;
        private const float DEATH_POSITION_Y = -10;
        public void Init(Spawner spawner) {
            this.spawner = spawner;
        }
        void Update() {
            if (transform.position.y < DEATH_POSITION_Y) {
                spawner.Despawn(this);
            }
        }
    }
