    void Start()
    {
        for (int i = 0; i < ThingToKill.Length; i++)
        {
            Debug.Log(ThingToKill[i].name);
            ThingToKill[i].SetActive(false);
            StartCoroutine("turnOn");
            StartCoroutine("turnOff");
        }
    }
