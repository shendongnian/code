    public float timeLeft_A = 0f;
    public float timeLeft_B = 0f;
    public float totalTime_A = 15f;
    public float totalTime_B = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cooldown(totalTime_A, (i) =>
        {
            timeLeft_A = i;
        }));
        StartCoroutine(Cooldown(totalTime_B, (i) =>
        {
            timeLeft_B = i;
        }));
    }
    IEnumerator Cooldown(float totalTime, Action<float> callback)
    {
        var timeLeft = totalTime;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            callback(--timeLeft);
        }
    }
