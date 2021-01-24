        class Engine
        {
            public bool Running { get; private set; }
            
            public void Start()
            {
                this.Running = true;
            }
            public void Stop()
            {
                this.Running = false;
            }
        }
