    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check to see if it has the "NPC" tag
        if(collision.tag == "NPC")
        {
            // Set "nearNPC" bool to tue
            nearNPC = true;
            NPCPrototype = collision.gameObject.GetComponent<BasicNPCPrototype>();
        }
    }
