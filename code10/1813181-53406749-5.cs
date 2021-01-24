    using UnityEngine;
    using System.Collections;
    
    public class Slime: MonoBehaviour
    {
        Transform player;        // Ref to the player's position.
        NavMeshAgent nav;        // Ref to the nav mesh agent.
    
        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            nav = GetComponent <NavMeshAgent> ();
        }
    
    
        void Update ()
        {
    		//Here it would be nice to add a stop condition, like when the player is dead or when it is out of range
    		ChasePlayer();
    
        } 
    	
    	void ChasePlayer() {
    		nav.SetDestination (player.position);
    		Debug.Log ("Chasing player");
    	}
    }
