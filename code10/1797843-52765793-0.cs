    public float totalSeconds = 2;     // The total of seconds the flash wil last
    public float maxIntensity = 8;     // The maximum intensity the flash will reach
    public Light myLight;
    
    void Awake()
    {
        //Find the RedLight
        GameObject redlight = GameObject.Find("TrafficLight_A/RedLight");
        //Get the Light component attached to it
        myLight = redlight.GetComponent<Light>();
    }
    
    public IEnumerator flashNow()
    {
        float waitTime = totalSeconds / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)
        while (myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
            yield return null;
        }
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;        //Decrease intensity
            yield return null;
        }
        yield return null;
    }
