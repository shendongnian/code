    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //side to side movement
                    if (touch.position.x < Screen.width / 2)
                        // I think you mean rb.velocity.y here instead of transform.position.y 
                        rb.velocity = new Vector2(- 2f, rb.velocity.y);
                    if (touch.position.x > Screen.width / 2)
                        rb.velocity = new Vector2(+ 2f, rb.velocity.y);
                }
                break;
            case TouchPhase.Ended:
                rb.velocity = new Vector2(0f, 0f);
                break;
        }
    }
    ...
    switch (JetOn)
    {
        case true:
            StartCoroutine(BurnFuel());
            rb.velocity += new Vector2(0f, JumpForce) / rb.mass;
            break;
        case false:
            // unnecessary but included for example purposes
            // rb.velocity += new Vector2(0f, 0f) / rb.mass;
            break;
    }
