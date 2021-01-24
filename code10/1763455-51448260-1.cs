     // Declared outside of your update makes these class variables that
     // will live as long as this object exists.
     int w = 0; // May be better to change this to cursorXPos
     int h = 0; // May be better to name this cursorYPos
     public void Update()
     {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                w--;
                if (w < 0)
                    w = width -1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                w++;
                if (w >= width)
                    w = 0;
            }
    
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                h--;
                if (h < 0)
                    h = height -1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                h++;
                if (h >= height)
                    h = 0;
            }
             
            Cursor.transform.position = pieces[w, h].transform.position; 
     }
