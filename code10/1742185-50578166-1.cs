    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponentInChildren<Pickup>())
        {
            _weaponPrefab = other.GetComponentInChildren<Pickup>().prefab;
        }
    }
