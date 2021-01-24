    public Text PickUpText;
    
    void OnDisable()
    {
        PickUpText.gameObject.SetActive(false);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.gameObject.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.gameObject.SetActive(false);
        }
    }
