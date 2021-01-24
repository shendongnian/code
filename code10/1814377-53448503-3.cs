    using UnityEngine;
    
        public class Controller: MonoBehaviour
        {
            GameObject enemyPrefab;
        
            List<GameObject> enemiesList = new List<GameObject>();
            
            void Start()
            {
              GameObject enemy = Instantiate(enemiePrefab, transform.position, transform.rotation);
              enemiesList.Add(enemy);
            }
        }
