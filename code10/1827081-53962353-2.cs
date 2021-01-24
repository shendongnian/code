    public RectTransform rectTransform; // panel RectTransform assigned to this variable
    ...
    void Update ()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3[] panelCorners = new Vector3[4];
        rectTransform.GetWorldCorners(panelCorners);
        if (mousePosition.x > panelCorners[0].x &&
            mousePosition.x < panelCorners[2].x &&
            mousePosition.y > panelCorners[0].y &&
            mousePosition.y < panelCorners[2].y)
        {
            SwipeDetection();
        }
        else 
        {
            fingerStart = Input.mousePosition;
        }
    }
