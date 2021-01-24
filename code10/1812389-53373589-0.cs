    public GameObject objToRotate;
    private bool rotating = false;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !rotating)
        {
            StartRotation();
        }
    }
    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        rotating = true;
        Quaternion startRotation = objToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        objToRotate.transform.rotation = endRotation;
        
    }
    public void StartRotation()
    {
        if (!rotating)
            StartCoroutine(Rotate(new Vector3(0, 0, -90), 1.1f));
    }
