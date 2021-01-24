    public Dictionary<GameObject, float> winners = new Dictionary<GameObject, float>();
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Bot1":
                winners.Add(other.gameObject, timer);
                break;
        }
        // ...
        Debug.Log(other.gameObject.tag + " Finished");
        Debug.Log(winners[other.gameObject].ToString());
    }
