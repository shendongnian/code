    public RectTransform rectTransform; // panel RectTransform assigned to this variable
    ...
    void Update ()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector2 normalizedMousePosition = new Vector2(mousePosition.x / Screen.width, 
                                                      mousePosition.y / Screen.height);
        if (normalizedMousePosition.x > rectTransform.anchorMin.x &&
            normalizedMousePosition.x < rectTransform.anchorMax.x &&
            normalizedMousePosition.y > rectTransform.anchorMin.y &&
            normalizedMousePosition.y < rectTransform.anchorMax.y)
        {
            SwipeDetection();
        }
        else 
        {
            fingerStart = Input.mousePosition;
        }
    }
