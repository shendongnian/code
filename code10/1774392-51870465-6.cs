    using UnityEngine; 
    public class ObjectEnabler : MonoBehaviour
    {	
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
            RegisterCallbacks();
        } 	
    
        private void OnDisable()	
        {		
            UnregisterCallbacks();
        }
        // Register callbacks for controler events
        private void RegisterCallbacks()
        {
            // It is always save to remove callbacks 
            // So just to be sure we only register once so methods are not executed twice
            // I personaly always first unregister callbacks:
            UnregisterCallbacks();
    
            // now I register the callback that means e.g.
            // Everytime the event TriggerClicked is 
            // invoked anywhere in the Scene I want to execute HandleTrickerClicked
            // hint the method can be called as you like .. could also simply be EnableObject e.g.
           	_controller.TriggerClicked += HandleTriggerClicked;		
            _controller.PadClicked += HandlePadClicked;	
            // For more information how the callbacks work
            // see the link I provided
        }
        // Unregister callbacks for events
        private void UnregisterCallbacks()
        {
            _controller.TriggerClicked -= HandleTriggerClicked;		
            _controller.PadClicked -= HandlePadClicked;	
        }
    
        // Called on TriggerClicked
        // Enables the obj1
        private void HandleTriggerClicked()	
        {
            obj1.SetActive(true);
        } 	
    
        // Called on PadClicked
        // Disables the obj1
        private void HandlePadClicked()
       	{
            obj1.SetActive(false);
        } 
    }
