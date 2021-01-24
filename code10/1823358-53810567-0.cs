     if (Input.GetMouseButtonDown(0))
     {
       line.enabled = !line.enabled;
       if (line.enabled)
         CreatePoints();
     }
