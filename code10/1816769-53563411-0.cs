    // if movement was greater than interpret as swipe 
    public float swipeThreshold = 0.01;
    Vector2 startPosition ;
    float movedDistance;
    
    Touch touch;
    
    void Update () 
    {
        if (Input.touchCount <= 0) return;
    
        switch(Input.GetTouch(0).phase)
        {
            case TouchPhase.Began:
                // On begin only save the start position
    
                touch = Input.GetTouch(0);
    
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return;
                }
    
                startPosition = touch.position;
                movedDistance = 0;
                break;
    
            case TouchPhase.Moved:
                // if moving check how far you moved
    
                movedDistance = Vector2.Distance(touch.position, startPosition );
                break;
    
            case TouchPhase.Ended:
                // on end of touch (like button up) check the distance
                // if you swiped -> moved more than swipeThreshold
                // do nothing
    
                if(movedDistance > swipeThreshold) break;
                
                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit, 100)) break;
                    
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else
                {
                    motor.MoveToPoint(hit.point);
                    RemoveFocus();
                }
                break;
    
            default:
                break;
        }
    }
