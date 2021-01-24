    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter " + collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            thePlayer.startPoint = spawnPortal;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
