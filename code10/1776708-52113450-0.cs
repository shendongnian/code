	public x_time aTime;
	[Range(0,10)]
	public  float molo = 0f; 
	[Range(0,10)]
	public float mola=0f;
	void Update()
	{
		// this will simply increase the value 
		if (Input.GetKeyDown ("u"))
		{
			StartCoroutine (SimplyIncrease (10f, 6f)); //<-- it does reach 10 in less than 6sec why?
		}
	}
    IEnumerator SimplyIncrease(float toValue, float during) {
        x_time timer = new x_time();
        IEnumerator e = timer.SimplyIncrease(toValue, during);
        while (e.MoveNext()) {
            molo = timer.position;
            yield return e.Current;
        }
        molo = toValue;
    }
}
