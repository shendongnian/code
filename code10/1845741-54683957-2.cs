    public Dictionary<GameObject, float> winners = new Dictionary<GameObject, float>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot1"))
        {
            Debug.Log("Bot1 Finished");
            currentTimeBot1 = timer;
            Debug.Log(currentTimeBot1.ToString());
             winners.Add(other.gameObject, timer);
        }
        // ...
    }
