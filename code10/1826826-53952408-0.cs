    using UnityEngine;
    
    public class spawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public float spawnHeight = 0.75f;
        private GameObject enemyClone //Added to allow enemyClone to be used anywhere in the class
        // Start is called before the first frame update
        void Start()
        {
            spawnEnemy();
        }
        // Update is called once per frame
        void Update()
        {
            if (enemyClone.transform.position.y < -10)
            {
                Destroy(enemyClone);
                spawnEnemy();
            }
        }
        public void spawnEnemy()
        {
            var enemyPosition = new Vector3(Random.Range(-5, 5), spawnHeight, Random.Range(-5, 5));
            enemyClone = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        }
    }
