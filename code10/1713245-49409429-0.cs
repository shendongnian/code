    void Update() 
    {
        if (SpawnFire < 20 && Time.time > SpawnFire) {
            SpawnFire = Time.time + SpawnRate;
            GameObject copy = Instantiate(NPC, NPCspawn1.position, NPCspawn1.rotation);
            navmesh nm = copy.GetComponent<navmesh>();
            nm._patrolpoints = master_array_of_patrol_points;
        }
    }
