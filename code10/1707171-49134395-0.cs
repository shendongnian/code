    Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
        
             if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit))
             {
                 if (hit.collider != null && hit.collider.tag != "yourObjectTag")
                    // do stuff here
             }
        }
    }
