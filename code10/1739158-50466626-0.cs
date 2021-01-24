    public class EnemyMovement : MonoBehaviour
    {
        NavMeshAgent nav; 
    	
    	function Awake ()
    	{
    		nav = GetComponent(NavMeshAgent);
    	}
    
        //So here it will be chasing the player
    	function Update ()
    	{
    		nav.SetDestination (player.position);
    	}
    }
