    using UnityEngine;
    using System.Collections;
    
    public class SpawnHazards : MonoBehaviour {
    
        #region Variables
        //Public
        //Private
        [SerializeField]
        private float minX = 0.0f;
        [SerializeField]
        private float maxX = 0.0f;
        [SerializeField]
        private GameObject[] hazards;
        [SerializeField]
        private float timeBetweenSpawns = 0.0f;
        //private bool canSpawn = false;
        private int amountOfHazardsToSpawn = 0;
        private int hazardsToSpawn = 0;
        #endregion
    
        #region UnityFunctions
        void Start() {   
            //canSpawn = true;
        }
    
        void Update() {    
            timeBetweenSpawns -= Time.deltaTime;
            //if(canSpawn == true)
            if(timeBetweenSpawns < 0.0f)
            {
                //StartCoroutine("GenerateHazard");
                GenerateHazard();
            }    
        }
        #endregion
        private void GenerateHazard()
        {
            //canSpawn = false;
            timeBetweenSpawns = Random.Range(0.5f, 2.0f); //Testing values
            amountOfHazardsToSpawn = Random.Range(1, 6);  //Testing values
    
            for(int i =0; i < amountOfHazardsToSpawn; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), 15.0f, 0.0f); // generate spawn position
                Instantiate(hazards[hazardsToSpawn], spawnPos, Quaternion.identity);  //spawn hazards
            }
    
            //yield return new WaitForSeconds(timeBetweenSpawns);
            //canSpawn = true;  
        }
    }
