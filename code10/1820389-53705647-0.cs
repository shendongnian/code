        public float SlowDownFactor = 0.05f;
        public float SlowdownLength = 2f;
    
        private float originalTimeScale;
        private float originalFixedDeltaTime;
    
        public void DoSlowMotion () {   
    
            // before changing store current values
            originalTimeScale = Time.timeScale;
            originalFixedDeltaTime = Time.fixedDeltaTime;
     
            Time.timeScale = SlowDownFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale ;
        }
        
        public void ResetTimeScales()
        {
            Time.timeScale = originalTimeScale;
            Time.fixedDeltaTime = originalFixedDeltaTime;
        }
