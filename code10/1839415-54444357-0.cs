    private void OnTriggerEnter2D(Collider2D collision)
    {
        tapObject.GetComponent<Renderer>().enabled = false;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        tapObject.GetComponent<Renderer>().enabled = true;
    }
