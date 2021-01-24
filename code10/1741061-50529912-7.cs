    string[] dObjects = new string[] { "FallingKeule(Clone)", "FallingHeart(Clone)", "FallingCup(Clone)" };
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            if(dObjects.Contains(transform.gameObject.name))
            {
                Destroy(transform.gameObject);
            }
            else
            {
                print("You lost a life!");
                Player.GetComponent<Colliding>().Destroy(transform.gameObject);
            }
        }
    }
