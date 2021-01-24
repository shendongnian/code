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
