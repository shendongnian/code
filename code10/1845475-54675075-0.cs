    float lastPosition;
    void OnSwipte(float delta)
    {
    // code your movement here
    }
    void Update()
    {
     if (Input.GetMouseButtonDown(0)) 
           lastPosition=Input.mousePosition.x; // store touch point
      else 
      if (Input.GetMouseButton(0)) 
        {
         OnSwipe(Input.mousePosition.x-lastPosition);
         lastPosition=Input.mousePosition.x; 
        }
       }
