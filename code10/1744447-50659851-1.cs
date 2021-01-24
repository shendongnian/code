    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj1 = this.gameObject;
        GameObject obj2 = collision.gameObject;
    
        Debug.Log("Triggered Obj1: :" + obj1.name);
        Debug.Log("Triggered obj2: :" + obj2.name);
    }
