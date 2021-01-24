    public int touchIndex = 0;
    
    void Update()
    {
        Touchscreen touchscreen = UnityEngine.Experimental.Input.Touchscreen.current;
    
    
        if (touchscreen.allTouchControls[touchIndex].ReadValue().phase != PointerPhase.None &&
                   touchscreen.allTouchControls[touchIndex].ReadValue().phase != PointerPhase.Ended)
        {
            Vector2 touchLocation = touchscreen.allTouchControls[touchIndex].ReadValue().position;
    
        }
    }
