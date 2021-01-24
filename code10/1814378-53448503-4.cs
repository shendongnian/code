    using UnityEngine;
    
    public class Controller : MonoBehaviour
    {
        public GameObject enemyPrefab;
    
        private List<GameObject> enemiesList = new List<GameObject>();
        public List<GameObject> wayPoints = new List<GameObject>();
    
        void Start()
        {
          GameObject enemy = Instantiate(enemiePrefab, transform.position, transform.rotation);
          enemy.wayPoints = wayPoints;
          enemiesList.Add(enemy);
        }
    }
