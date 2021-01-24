    public float speed = 5;
    public Rigidbody rb;
    public void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        //Add touch support
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.touches[0];
            h = touch.deltaPosition.x;
        }
        //Move only if we actually pressed something
        if (h > 0 || h < 0)
        {
            Vector3 tempVect = new Vector3(h, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            //rb.MovePosition(rb.transform.position + tempVect);
            Vector3 newPos = rb.transform.position + tempVect;
            checkBoundary(newPos);
        }
    }
    void checkBoundary(Vector3 newPos)
    {
        //Convert to camera view point
        Vector3 camViewPoint = Camera.main.WorldToViewportPoint(newPos);
        //Apply limit
        camViewPoint.x = Mathf.Clamp(camViewPoint.x, 0.04f, 0.96f);
        camViewPoint.y = Mathf.Clamp(camViewPoint.y, 0.07f, 0.93f);
        //Convert to world point then apply result to the target object
        Vector3 finalPos = Camera.main.ViewportToWorldPoint(camViewPoint);
        rb.MovePosition(finalPos);
    }
