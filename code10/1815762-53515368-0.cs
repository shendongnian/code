    public class BoundsCheck: MonoBehaviour
    {
        public bool isInside = false;
        public bool isPlayedOnce = false;
        private Bounds bounds;
        
        void Start()
        {
            bounds = new Bounds(new Vector3(-9.5f, 0, -9.5f), new Vector3(39.0f, 0f, 39.0f));
        }
    
       
        void Update()
        {
            CheckBounds();// play the sound if the player is outside some boundaries
            if (!isInside &&!isPlayedOnce)
            {
                Debug.Log("PLAY");
                isPlayedOnce = true;
            }
        }
    
        private void CheckBounds()
        {
    
            
            bool isInsideBound = bounds.Contains(transform.position);
            if (isInsideBound)
            {
                isInside = true;
                if (isPlayedOnce)
                {
                    isPlayedOnce = false;
                }
            }
            else
            {
                isInside = false;
            }
        }
    }
