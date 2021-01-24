    Vector2 lastMousePosition;
    void WhenMouseIsMoving()
    {
    }
    void WhenMouseIsntMoving()
    {
    }
    void Update()
    {
     if (Input.mousePosition!=lastMousePosition)
     {
       lastMousePosition=Input.MousePosition;
       WhenMouseIsMoving();
      } else
       WhenMouseIsntMoving();
    }
