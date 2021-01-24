    public class Movement : MonoBehaviour {
            //Point towards the instantiated Object will move
            Transform goal;
            //Reference to the NavMeshAgent
            UnityEngine.AI.NavMeshAgent agent;
     
            // Use this for initialization
            void Start () {
                //You get a reference to the destination 
                goal = GameObject.Find("Destination").GetComponent<Transform>();
                //Here you get a reference to the NavMeshAgent
                 agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    			//You indicate to the agent to what position it has to move
                agent.destination = goal.position;
            }
        	
    }
