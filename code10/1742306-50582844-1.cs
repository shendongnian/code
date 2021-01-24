      public GameObject deathParticlePrefab;
            
            private void OnTriggerEnter2D(Collider2D collision)
                {
                    #rest of the code
                    deathParticlePrefab.SetActive(true);
                    
                }
            public void RespawnPlayer()
            {
                //rest of the code
                deathParticlePrefab.SetActive(false);
            }
         
