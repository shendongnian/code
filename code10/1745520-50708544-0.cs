    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(gameObject.tag) == false)
            Debug.Log("This is NOT the same Color!");
        else
            Debug.Log("This is the same Color!");
    }
