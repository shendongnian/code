    public void Initialize()
    {
        player.CreateVariable<int>("HP");
        player.CreateVariable<bool>("StartedKill5RatsQuest");
        player.Set("HP", 10);
        player.Set("StartedKill5RatsQuest", true);
    }
    public void Update()
    {
         ...
         if(player.Get<bool>("StartedKill5RatsQuest"))
         {
             ...
         }
    }
