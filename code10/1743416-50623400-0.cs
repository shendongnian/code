    if (Input.GetMouseButtonDown(0))
    {
        Camera cam = Camera.main;
    
        Vector2 wPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(wPoint, Vector2.zero);
    
        //Check if we hit anything
        if (hit)
        {
            if (hit.collider.GetComponent<BoxCollider2D>() != null)
            {
                Debug.Log("Bad Click");
            }
            else if (hit.collider.GetComponent<PolygonCollider2D>() != null)
                Debug.Log("Good Click");
        }
    }
