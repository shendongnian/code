    void Update()
    {
        if( LoopAttachmentCheck() )
        {
            // We enable this to prevent the character from falling
            rb.isKinematic = true;
            // Here you write the code that allows the character to move
            // in a circle, e.g. via a bezier curve, at the currentSpeed.
        }
        else
        {
            rb.isKinematic = false;
        }
    }
