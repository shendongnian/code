    if (isMousePressed)
    {
        var stopDrawing = false;  
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "square" || hit.transform.tag == "circle") {
                stopDrawing  = true;
            }
        }
        if(stopDrawing) 
        {
            // Stop current line, prepare a new List<Vector3> for next line
        }
        else{
            // Continue draw current line
        }
    }
