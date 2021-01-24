     public void Pause() 
        {
            if (Time.timeScale == 1) 
            {
                Time.timeScale = 0;
            }
           else if (Time.timeScale == 0)
            {
                Time.timeScale = 1; //Resume Game..
            }
        }
 
