    using UnityEngine;
    public class GameBehaviour : MonoBehaviour {
        public GameObject Agent;
        public Transform SpawnPoint;
        public Transform Destination1;
        public Transform Destination2;
        public Transform Destination3;
    	// Use this for initialization
    	void Start()
        {
            Agent.SetActive(false);
            InvokeRepeating("Spawn", 0f, 2f);
    	}
    	
    	void Spawn() {
            var newAgent = Instantiate(Agent);
            newAgent.GetComponent<NavAgentBehaviour>().Destinations = new[] { Destination1, Destination2, Destination3 };
            newAgent.transform.position = SpawnPoint.position;
            newAgent.SetActive(true);
    	}
    }
