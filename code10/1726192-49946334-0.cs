    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach(GameObject obst in obstacles)
                obst.GetComponent<RigidBody>().useGravity = false;
            GameManager.restartDelay = 4f;
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
