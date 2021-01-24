    public RectTransform rectTransform; // panel RectTransform assigned to this variable
    ...
    void Update ()
    {
        Vector2 mousePosition = Input.mousePosition;
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
        {
            SwipeDetection();
        }
        else 
        {
            fingerStart = Input.mousePosition;
        }
    }
