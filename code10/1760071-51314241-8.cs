    using UnityEngine;
    using UnityEngine.AI;
    public class NavAgentBehaviour : MonoBehaviour {
        public Transform[] Destinations { get; set; }
    	// Use this for initialization
    	void Start ()
        {
            InvokeRepeating("changeDestination", 0f, 3f);
    	}
        void changeDestination()
        {
            var agent = GetComponent<NavMeshAgent>();
            agent.destination = Destinations[Random.Range(0, Destinations.Length)].position;
        }
    }
