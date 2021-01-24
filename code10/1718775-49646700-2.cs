    public class RaySenderScript{
        RaycastHit Hit;
        void FixedUpdate(){
            //SendRaycast and store in 'Hit'.
            if (Hit.collider != null)
               { //If raycast hit a collider, attempt to acquire its receiver script.
                   RayReceiverScript = Hit.collider.gameObject.GetComponent<RayReceiverScript>();
                   if (RayReceiverScript != null)
                      { //if receiver script acquired, hit it.
                          RayReceiverScript.HitWithRay();
                      }
               }
        }  
    }
