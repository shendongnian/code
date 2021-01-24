    public GameObject mPlayer;
    PlayerScript mPlayerScript;
    
    Start(){
        mPlayerScript = mPlayer.GetComponent<PlayerScript>();
    }
    
    
    
    if(score > 30)
    {
      int rand = Random.Range(0, 6);
      if (rand < 3)
      {
         SpawnNegX();
         mPlayerScript.SwitchDirection();
      }
      else if(rand >= 3)
      {
         SpawnZ();
         mPlayerScript.SwitchDirection();
      }
    }
