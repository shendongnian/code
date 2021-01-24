    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Once) return;
    
        var light= collision.GetComponent<Light>();
        if(!light)
        {
            Debug.Log("No Lightfound on collision" + collision.name, this);
            return;
        }
    
        Debug.Log("It's true");
        if (light.enabled) // It needs to check this constantly
        {
            Debug.Log(" It's Lit");
            Instantiate(Prefab1, Spawnpoint1.position, Spawnpoint1.rotation);
            Instantiate(Prefab2, Spawnpoint2.position, Spawnpoint2.rotation);
    
            Once = false;
        }
    }
