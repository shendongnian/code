    void Update()
    {
        // Here
        if (Input.GetMouseButtonDown(1))
        {
            currentX = transform.eulerAngles.y;
            currentY = transform.eulerAngles.x;
        }
        if (Input.GetMouseButton(1))
        { 
            ...
