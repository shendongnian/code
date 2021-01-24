    void Awake() {
    	for (int i = 0; i < 100; i++) { CallAllCoroutines += TestA; }
    }
    void Update() {
    	if (Input.GetMouseButtonDown(1)) { MassEventTest(); }
    }   
     
    public delegate void CastEvent();
    public event CastEvent CallAllCoroutines;
    async void MassEventTest() {
    	Debug.Log("Invoking event");
    	CallAllCoroutines();
    	await Task.Delay(1000);
    	Debug.Log("Can continue");
    }
    
    void TestA() { StartCoroutine(TestCoroutine()); }
    IEnumerator TestCoroutine() {
    	Debug.Log("Starting Coroutine");
    	yield return new WaitForSeconds(1);
    	Debug.Log("Ending Coroutine");
    }
