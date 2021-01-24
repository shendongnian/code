    public static event System.Action onSunglassesCompleted;
    public IEnumerator Sunglasses()
    {
        //Sunglasses logic here
        //if there is a listener to the event, call it
        if(onSunglassesCompleted != null)
        {
            onSunglassesCompleted();
        }
    }
