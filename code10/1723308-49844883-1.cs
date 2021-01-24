    if (Input.GetMouseButtonDown(0))
    {
        int di = GetHoveredDisplay();
        Camera currentDisplayCamera = cameras[di];
        Ray ray = currentDisplayCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // etc ...
        }
    }
