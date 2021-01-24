    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponentInChildren<Pickup>())
        {
            var item = other.GetComponentInChildren<Pickup>().item;
            _weaponPrefab = item.prefab;
        }
    }
