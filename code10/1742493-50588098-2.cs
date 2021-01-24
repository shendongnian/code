    public void Pause() //Function to take care of Pause Button.. 
    {
    
        print("Entered Pause Func");
        if (Time.timeScale == 1 && paused == false) //1 means the time is normal so the game is running..
        {
            print("Enterer first if");
            Time.timeScale = 0; //Pause Game..
            return;
        }
        else
        {
            Time.timeScale = 1; //Resume Game..
        }
    }
