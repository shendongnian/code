    private TimeClass ts;
	void Start ()
	{
	    ts = ...; //Inject
	}
    void OnTriggerEnter ()
    {
        ts.RunCoroutine(); //Implement logic in TimeClass
        Destroy(gameObject);
    }
