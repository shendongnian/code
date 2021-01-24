    private void OnCollisionEnter(Collision collision)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetTrigger("spider");
    
        }
    }
