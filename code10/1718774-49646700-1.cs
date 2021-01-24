    public class RayReceiverScript{
        public float HitByRayRefreshTime = 1f;
        float RayRunsOutTime;
        public bool IsHitByRay = false;
        void Start()
        {   //Initialize run out time.
            RayRunsOut = Time.time;
        }
        void Update()
        {
            if (Time.time > RayRunsOutTime)
            { //check if time run out, if it has, no longer being hit by ray.
                IsHitByRay = false;
            }
        }
        
        void HitWithRay(){ //method activated by ray sender when hitting this target.
             IsHitByRay = true;
             RayRunsOutTime = Time.time + HitByRayRefreshTime;
        }  
    }
