    using UnityEngine;
    
    public class Raycasting : MonoBehaviour {
    
        [SerializeField]
        private LayerMask pointMask; //Set this to the same tag as any GameObject you consider a "point"
        private Vector2 pointA, distance;
    
        private void Update()
        {
            CheckForPoint();
    
            Debug.Log(distance);
        }
    
        private void CheckForPoint()
        {
            pointA = transform.position; //The GameObject's current position in the world
    
            RaycastHit2D pointB =  Physics2D.Raycast(pointA, Vector2.right * Mathf.Sign(transform.localScale.x), Mathf.Infinity, pointMask);
            //Draws a visible ray in the game view (must have gizmos enabled)
            Debug.DrawRay(pointA, Vector2.right * Mathf.Sign(transform.localScale.x), Color.green); 
    
            if (pointB)
            {
                distance = (Vector2)pointB.transform.position - pointA;
            }
        }
    }
