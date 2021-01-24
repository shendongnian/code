    public void Start()
    {
        // existing components on the GameObject
        AnimationClip clip;
        // new event created
        AnimationEvent evt;
        evt = new AnimationEvent();
        // put some parameters on the AnimationEvent
        //  - call the function called PrintEvent()
        //  - the animation on this object lasts 2 seconds
        //    and the new animation created here is
        //    set up to happen 1.3s into the animation
        evt.intParameter = 12345;
        evt.time = 1.3f;
        evt.functionName = "PrintEvent";
        clip.AddEvent(evt);
    }
    // the function to be called as an event
    public void PrintEvent(int i)
    {
        print("PrintEvent: " + i + " called at: " + Time.time);
    }
