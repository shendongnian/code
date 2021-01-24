     ParticleSystem deathParticleSystem;
        
        private void OnTriggerEnter2D(Collider2D collision)
            {
                #rest of the code
                deathParticleSystem.time = 0;
                deathParticleSystem.Play();
                
            }
        public void RespawnPlayer()
        {
            //rest of the code
            deathParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    
