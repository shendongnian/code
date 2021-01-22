    class MyDerived : MyBase
    {
        private string sampleObject;
        protected bool started = false;
        public MyDerived (string initObject)
        {
            sampleObject = initObject;
            if (Initialize(this)) // if this is the most derived constructor, this will run Initialize() and return whether it was successful
                this.Start();
        }
        protected override bool Initialize() 
        { 
           return GetDevice();
        }
        public override void Start() 
        { 
            // if Start() would be protected, we don't need the IsInitialized property and we can move this check to the constructor on the returned value of the Initialize<T>() call.
            if (!IsInitialized) throw new InvalidOperationException("Initialization failed.");
            // if you want to have this method exposed public, we need to check if this instance is successfully initialized from the constructor and not in started state already.
            if (started) return;
            Console.WriteLine("Processing " + sampleObject.ToString()); 
            started = true;
            if (!Run(sampleObject)) started = false;
        }
    }
