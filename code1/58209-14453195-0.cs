    int[] keyVals;
    TimeSpan pressWait = new TimeSpan(0, 0, 1);
    Dictionary<Keys, bool> keyDowns = new Dictionary<Keys, bool>();
    Dictionary<Keys, DateTime> keyTimes = new Dictionary<Keys, DateTime>();
    
    public ConstructorNameHere
    {
        keyVals = Enum.GetValues(typeof(Keys)) as int[];
        foreach (int k in keyVals)
        {
            keyDowns.Add((Keys)k, false);
            keyTimes.Add((Keys)k, new DateTime()+ new TimeSpan(1,0,0));
        }
    }
    protected override void Update(GameTime gameTime)
    {
        foreach (int i in keyVals)
        {
            Keys key = (Keys)i;
            switch (key)
            {
                case Keys.Enter:
                    keyTimes[key] = (Keyboard.GetState().IsKeyUp(key)) ? ((keyDowns[key]) ? DateTime.Now + pressWait : keyTimes[key]) : keyTimes[key];
                    keyDowns[key] = (keyTimes[key] > DateTime.Now) ? false : Keyboard.GetState().IsKeyDown(key);
                       
                    if (keyTimes[key] < DateTime.Now)
                    {
                        // Code for what happens when Keys.Enter is pressed goes here.
                    }
                    break;
        }
    }
  
