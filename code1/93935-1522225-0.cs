    void Main()
    {
        Light[] lights = new Light[300];
        int i=0;
        Random rand = new Random();
        while(i<270)
        {
            int tryIndex = rand.Next(270);
            if(lights[tryIndex] == Light.NotSet)
            {
                lights[tryIndex] = Light.Green;
                i++;
            }
        }
        for(i=0;i<300;i++)
        {
            if(lights[i] == Light.NotSet)
            {
                lights[i] = Light.Red;
            }
        }
    
        //iterate over lights and do what you will
    }
    
    
    enum Light
    {
        NotSet,
        Green,
        Red
    }
