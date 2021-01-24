    //Set in inspector
    public Renderer renderer
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        renderer.enabled = false;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        renderer.enabled = true;
    }
