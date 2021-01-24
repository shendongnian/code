    using UnityEngine;
    
    public class LightDrone : MonoBehaviour
    {
        public float speed = 60.0f;
    
        // Our destination needs to be remembered outside a single iteration of
        // Update. So we put it outside of the method in order to remember it
        // across multiple frames.
        private Vector3 currentDestination;
    
        // We need to check if we're at the destination yet so we know when to stop.
        private bool notAtDestinationYet;
    
        // When we're closer to the destination than this tolerance, we decide that
        // we have arrived there.
        private float tolerance = 0.1f;
    
        private void  Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    var newPosition = hit.point;
                    // You can add whatever height you want here. I added
                    // just 2 instead of 10.
                    currentDestination = newPosition + new Vector3(0, 2.0f, 0);
                    notAtDestinationYet = true;
                }
            }
    
            if (notAtDestinationYet)
            {
                // Use a bit of vector math to get the direction from our current
                // position to the destination. The direction is a normalized Vector
                // that we can just multiply with our speed to go in that direction
                // at that specific speed!
    
                var heading = currentDestination - transform.position;
                var distance = heading.magnitude;
                var direction = heading / distance;
    
                // Check if we've arrived at our destination.
                if (distance < tolerance)
                {
                    notAtDestinationYet = false;
                }
                else
                {
                    // If the remaining distance between us and the destination is
                    // smaller than our speed, then we'll go further than necessary!
                    // This is called overshoot. So we need to make our speed
                    // smaller than the remaining distance.
    
                    // We also multiply by deltaTime to account for the variable
                    // amount of time that has passed since the last Update() call.
                    // Without multiplying with the amount of time that has passed
                    // our object's speed will increase or decrease when the
                    // framerate changes! We really don't want that.
    
                    float currentSpeed = Mathf.Clamp(speed * Time.deltaTime,
                        Mathf.Epsilon, distance);
                    transform.position += direction * currentSpeed;
                }
            }
        }
    }
