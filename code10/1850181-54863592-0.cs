    public MouseLock mouseLook;
        
        void OnTriggerEnter(Collider target)
            {
                if (target.gameObject.tag == "Water")
                { 
                    Time.timeScale = 0.0f;
                    Time.fixedDeltaTime = 0.0f;
        
                    mouseLook.enabled = false;
                }
            }
