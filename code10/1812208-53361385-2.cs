    using UnityEngine;
    public class Test : MonoBehaviour {
    
        public Transform[] SpawnPoints;
        public Transform[] EffectPoints;
    
    
        public float spawnTime = 1.5f;
        public float effectSpawnTime = 1f;
    
        public GameObject Coins;
        public GameObject Effect;
       
        int spawnIndex = 0;
        int maximumRandomRange = 0;
        // Use this for initialization
        void Start()
        {
            //Initialize the variable
            spawnIndex = Random.Range(0, maximumRandomRange);
            maximumRandomRange = SpawnPoints.Length; //or EffectPoints.Length, as they got the same
    
            InvokeRepeating("SpawnParticle", effectSpawnTime, effectSpawnTime);
            InvokeRepeating("SpawnCoins", spawnTime, spawnTime);
        }
        
        void SpawnCoins()
        {
            Instantiate(Coins, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        }
        void SpawnParticle()
        {
            spawnIndex = Random.Range(0, maximumRandomRange); //You only need to call it here again, as it is the function which is called faster
            Instantiate(Effect, EffectPoints[spawnIndex].position, EffectPoints[spawnIndex].rotation);
        }
    
    }
