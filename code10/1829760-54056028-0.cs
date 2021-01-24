    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("End");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    } 
