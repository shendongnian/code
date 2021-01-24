        class Engine
        {
            public bool Running { get; private set; }
            public bool OutOfControl { get; private set; }
            public void Start()
            {
                if (this.OutOfControl) return;
                this.Running = true;
            }
            public void Stop()
            {
                if (this.OutOfControl) return;
                this.Running = false;
            }
            public void SomeOperation()
            {
                //inside the method sometimes OutOfControl is set to true
            }
        }
