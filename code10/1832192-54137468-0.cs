    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.collider.gameObject.name);
        Debug.Log(coll.otherCollider.gameObject.name);
        ...   
    }
