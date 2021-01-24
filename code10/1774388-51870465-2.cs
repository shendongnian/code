        private SteamVR_TrackedController _controller;	
        public GameObject obj1;
    
        private void OnEnable()	
        {		
             // Get the controller this component is attached to
             _controller = GetComponent<SteamVR_TrackedController>();	
    
             // Register callbacks to your buttons
             // I've left this on the ones from the example .. if you need others 
             // You have to look them up
             // In the example there is also a complete list of all button events
    
            // It is always save to remove callbacks 
            // So just to be sure we only register once so methods are not executed twice
            // I always first unregister callbacks:
            _controller.TriggerClicked -= HandleTriggerClicked;		
             _controller.PadClicked -= HandlePadClicked;	
    
             // now I register a callback that means
             // Everytime the event TriggerClicked is 
             // Invoked anywhere in the scene I want to execute HandleTrickerClicked
             // hint the method can be called as you like .. could also simply be EnableObject e.g.
           	_controller.TriggerClicked += HandleTriggerClicked;		
             _controller.PadClicked += HandlePadClicked;	
        } 	
    
        private void OnDisable()	
        {		
            _controller.TriggerClicked -= HandleTriggerClicked;
            _controller.PadClicked -= HandlePadClicked;	
        } 	
    
        // Enables the obj1
        private void HandleTriggerClicked()	
        {
            obj1.SetActive(true);
        } 	
    
        // Disables the obj1
        private void HandlePadClicked()
       	{
            obj1.SetActive(false);
        } 
    }
