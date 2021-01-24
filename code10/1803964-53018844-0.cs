    void OnCollisionEnter2D(Collider2D col) {
        // only activate once
        if (once) {
            // Get light if exists
            GameObject collidedObject = col.gameObject;
            Light light = collidedObject.GetComponentInChildren<Light>();
            if (light != null) {
                // We have a light, check if it's on. We only care about the collided light
                if (light.isOn) {
                    Debug.Log("It's Lit fam");
                    Instantiate(Prefab1, Spawnpoint1.position, Spawnpoint1.rotation);
                    Instantiate(Prefab2, Spawnpoint2.position, Spawnpoint2.rotation);
                    // Note that if we run into another lit light nothing will happen, 
                    // even if its the first time running into that particular light
                    Once = false;
                }
            }
        }
    }
