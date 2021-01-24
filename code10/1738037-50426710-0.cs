    Camera mainCamera;
    float zAxis = 0;
    Vector3 clickOffset = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        addEventSystem();
        zAxis = transform.position.z;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        clickOffset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, zAxis));
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Use Offset To Prevent Sprite from Jumping to where the finger is
        Vector3 tempVec = mainCamera.ScreenToWorldPoint(eventData.position) + clickOffset;
        tempVec.z = zAxis; //Make sure that the z zxis never change
        transform.position = tempVec;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    }
