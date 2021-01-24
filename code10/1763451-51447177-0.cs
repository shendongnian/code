     public void Update()
     {
        for (int h = 0; h < height; h++)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                h++;
                if (h > height)
                    h = 0;
            }
         }
         for (int w = 0; w < width; w++)
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
