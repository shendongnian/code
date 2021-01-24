    using UnityEngine;
        
        public class Enemy : MonoBehaviour
        {
           public List<GameObject> wayPoints = new List<GameObject>();
        
           public float speed;
           private Transform target;
           int waypointIndex = 0;
        
           private void Start()
           {
             target = List[waypointIndex].transform;
             waypointIndex++;
           }
           
            void Update()
            {
              // The step size is equal to speed times frame time.
              float step = speed * Time.deltaTime;
        
              // Move our position a step closer to the target.
              transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
              //If we arrive to the target, get the new target
              if(this.transform.position == target.position)
              {
                waypointIndex++;
                //if it is the last element, go to the first one again
                if(wayPointIndex > List.Count())
                {
                  wayPointIndex = 0;
                }            
                target = List[waypointIndex].transform;      
              }              
            }
        }
