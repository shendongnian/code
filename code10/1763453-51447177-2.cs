     public void Update()
     {
        for (int h = 0; h < width; h++)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                h++;
                if (h > height)
                    h = 0;
            }
         }
         for (int w = 0; w < height; w++)
         {
             if (Input.GetKeyDown(KeyCode.UpArrow))
             {
                 w++;
                 if (w > width)
                     w = 0;
             }
             // Cursor.transform.position = pieces[w, h].transform.position; ==> I suppose this is where it should be
         }            
        
     }
