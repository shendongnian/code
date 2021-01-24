    float rotateSpeed = 0.5f;
    bool hoverState = false;
    public void LookAtCube()
    {
        hoverState = true;
    }
    public void LookOutCube()
    {
        hoverState = false;
    }
    void Update()
    {
        if (hoverState)
            transform.Rotate(new Vector3(rotateSpeed, rotateSpeed, rotateSpeed));
    }
