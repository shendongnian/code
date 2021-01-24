    void Start()
    {
        Script1.onSunglassesCompleted += DoThisAfterSunglasses;
    }
    //This will be called in Script1
    void DoThisAfterSunglasses()
    {
        //Make sure you do this to avoid memory leaks or missing reference errors once Sprite1 is destroyed
        Script1.onSunglassesCompleted -= DoThisAfterSunglasses;
        Function1();
        String blah = "Things";
        Function2();
        StartCoroutine(Routine2());
        StartCoroutine(Routine3());
    }
