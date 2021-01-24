    public class SimpleSampleAgentBehaviour : MonoBehaviour {
        public Transform[] Anchors { get; set; }
    	// Use this for initialization
    	void Start ()
        {
            InvokeRepeating("changeDestination", 0f, 3f);
    	}
        void changeDestination()
        {
            var agent = GetComponent<NavMeshAgent>();
            agent.destination = Anchors[Random.Range(0, Anchors.Length)].position;
        }
    }
