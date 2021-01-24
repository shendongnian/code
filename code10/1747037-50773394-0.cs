    {
        private static bool created = false;
        public static Controller instance;
    
    	void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }
    
            if (!created)
            {
                DontDestroyOnLoad(this.gameObject);
                created = true;
            }
        }
    
        public void Respawn()
        {
            SceneManager.LoadScene(0);
            GameObject.Find("Player").transform.position = GameObject.Find("RespawnPoint").transform.position;
        }
    }
